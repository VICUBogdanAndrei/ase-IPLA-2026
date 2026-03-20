using System.Collections.Generic;
using System.IO;
using System.Linq;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Globalization;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;

namespace ListaStudentiApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string baseFileName = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Materiale", "students");
            string dataFilePath = baseFileName + ".txt";
            string wordFilepath = baseFileName + ".docx ";
            string xlsFilePath = baseFileName + ".xlsx";

            string xlsTemplateFilePath = baseFileName + "Template.xlsx";

            string siglaFilePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Materiale", "sigla.jpg");

            List<Student> students = File.ReadAllLines(dataFilePath)
                .Select(linie => new Student(linie))
                .OrderByDescending(stud => stud.Medie)
                .ThenBy(stud => stud.Nume).ToList();

            students.ForEach(student => Console.WriteLine(student));

            var wordApp = new Word.Application();
            var docuemnt = wordApp.Documents.Add();
            docuemnt.PageSetup.PaperSize = Word.WdPaperSize.wdPaperA4;
            Word.Range headerRange = docuemnt.Sections[1].Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            headerRange.InlineShapes.AddPicture(siglaFilePath);
            headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            Word.Range footerRange = docuemnt.Sections[1].Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            footerRange.Text = string.Format("Tiparit la data de {0}", DateTime.Now.ToString("dd MMM yyy", new CultureInfo("ro-RO")));
            footerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            var docRange = docuemnt.Range();
            docRange.Text = "List studenti";
            docRange.set_Style("Heading 1");
            docRange.Font.Color = Word.WdColor.wdColorBlue;
            docRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            docRange.InsertParagraphAfter();
            docRange.InsertParagraphAfter();

            docRange.Collapse(Word.WdCollapseDirection.wdCollapseEnd);

            var table = docRange.Tables.Add(docRange, students.Count + 1, 3);
            table.Cell(1, 1).Range.Text = "Nr.";
            table.Cell(1, 2).Range.Text = "Nunele";
            table.Cell(1, 3).Range.Text = "Media";
            
            for (int i = 0; i < students.Count; i++)
            {
                table.Cell(i + 2, 1).Range.Text = (i + 1).ToString();
                table.Cell(i + 2, 2).Range.Text = students[i].Nume;
                table.Cell(i + 2, 3).Range.Text = Convert.ToString(students[i].Medie);

                table.Cell(i + 2, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                table.Cell(i + 2, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                table.Cell(i + 2, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            }

            table.set_Style("Table professional");

            table.Columns.AutoFit();
            table.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow);

            docuemnt.SaveAs(wordFilepath);
            wordApp.Quit();

            Console.WriteLine(wordFilepath);
            Process.Start(wordFilepath);

            wordApp = null;

            Excel.Application excelApp = new Excel.Application();
            Workbook wb = excelApp.Workbooks.Open(xlsTemplateFilePath);
            Worksheet sheetData = wb.Worksheets[2];
            Excel.Range range = sheetData.Range["A2"];
            range.Value2 = 1;
            range.AutoFill(sheetData.Range["A2", "A" + (students.Count + 1)], XlAutoFillType.xlFillSeries);

            for(int i = 0;  i < students.Count; i++)
            {
                (sheetData.Cells[i + 2, 2] as Excel.Range).Value2 = students[i].Nume;
                (sheetData.Cells[i + 2, 3] as Excel.Range).Value2 = students[i].Medie;
            }

            sheetData.Range["C2", "C" + (students.Count + 1)].Name = "valori";

            wb.Close(SaveChanges: true, xlsFilePath);

            excelApp.DisplayAlerts = false;
            excelApp.Quit();

            excelApp = null;

            Process.Start(xlsFilePath);
        }
    }
}
