using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace WordDocument1
{
    public partial class UserControl1 : UserControl
    {
        object parola = "null";
        Word.WdProtectionType tipProtectie = Word.WdProtectionType.wdAllowOnlyFormFields;
        object lipsa = Type.Missing;
        
        class Produs
        {
            public decimal Pret {  get; set; }
            public string Denumire { get; set; }
            public string Um {  get; set; }

            public override string ToString()
            {
                return string.Format("{0} ({1:00} lei)", this.Denumire, this.Pret);
            }
        }

        List<Produs> produse = new List<Produs>()
        {
            new Produs(){Denumire = "Mere", Pret = 2.45m, Um ="kg"},
            new Produs(){Denumire = "Pere", Pret = 5m, Um ="kg"},
        };

        Word.Table tabel;

        public UserControl1()
        {
            InitializeComponent();

            foreach (Produs produs in produse)
            {
                this.cmbProduse.Items.Add(produs);
            }
            cmbProduse.SelectedIndex = 0;
            tabel = Globals.ThisDocument.Tables[3];

            Globals.ThisDocument.Protect(Word.WdProtectionType.wdAllowOnlyFormFields, ref lipsa, ref parola, ref lipsa, ref lipsa);

            Globals.ThisDocument.wdTextName.Exiting += wdTextName_Exiting;

        }

        private void wdTextName_Exiting(object sender, Microsoft.Office.Tools.Word.ContentControlExitingEventArgs e)
        {
            lblClient.Text = string.Format("Client: {0}",
                Globals.ThisDocument.wdTextName.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globals.ThisDocument.Unprotect(ref parola);
            var produs = cmbProduse.SelectedItem as Produs;

            var rand = tabel.Rows.Add(BeforeRow:
                tabel.Rows[tabel.Rows.Count - 2]);
            rand.Cells[2].Range.Text = produs.Denumire;
            rand.Cells[3].Range.Text = produs.Um;
            rand.Cells[4].Range.Text = numCantitate.Value.ToString("0.00");
            rand.Cells[5].Range.Text = produs.Pret.ToString("0.00");

            Recalculare();

            Globals.ThisDocument.Protect(tipProtectie, ref lipsa, ref parola, ref lipsa, ref lipsa);
        }

        void Recalculare()
        {
            decimal total = 0, TVA = 0;

            for (int i=3;i<tabel.Rows.Count-2;i++)
            {
                decimal pret = decimal.Parse(tabel.Rows[i].Cells[5].Range.Text
                    .Replace("\r\a", string.Empty));

                decimal cantitate = decimal.Parse(tabel.Rows[i].Cells[4].Range.Text
                    .Replace("\r\a", string.Empty));

                total += (pret * cantitate );
                TVA += (pret * cantitate * 0.21m);

                tabel.Rows[i].Cells[1].Range.Text = (i-2).ToString();
                tabel.Rows[i].Cells[6].Range.Text = (pret * cantitate).ToString("0.00");
                tabel.Rows[i].Cells[7].Range.Text = (pret * cantitate * 0.21m).ToString("0.00");
            }

            tabel.Rows[tabel.Rows.Count - 1].Cells[6].Range.Text = (total).ToString("0.00");
            tabel.Rows[tabel.Rows.Count - 1].Cells[7].Range.Text = (TVA).ToString("0.00");



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tabel.Rows.Count<6)
            { return; }
            Globals.ThisDocument.Unprotect(ref parola);
            tabel.Rows[tabel.Rows.Count-3].Delete(); 

            Recalculare();

            Globals.ThisDocument.Protect(tipProtectie, ref lipsa, ref parola, ref lipsa, ref lipsa);

        }

        private void buttonPDF_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Fisier PDF (*.pdf) | *.pdf";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Globals.ThisDocument.ExportAsFixedFormat(
                        dialog.FileName,
                        Word.WdExportFormat.wdExportFormatPDF, false,
                        Word.WdExportOptimizeFor.wdExportOptimizeForPrint,
                        Word.WdExportRange.wdExportAllDocument, 1, 1,
                        Word.WdExportItem.wdExportDocumentWithMarkup, true, true,
                        Word.WdExportCreateBookmarks.wdExportCreateNoBookmarks,
                        true, true, false, ref lipsa);

                    System.Diagnostics.Process.Start(dialog.FileName);
                }
            }
        }
    }
}
