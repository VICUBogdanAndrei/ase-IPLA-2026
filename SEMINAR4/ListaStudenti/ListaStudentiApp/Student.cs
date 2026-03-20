using System.Globalization;

namespace ListaStudentiApp
{
    public class Student
    {
        public Student(string linie)
        {
            string[] vector = linie.Split(',');
            this.Nume = vector[0];
            this.Medie = decimal.Parse(vector[1], CultureInfo.InvariantCulture);
        }

        public string Nume { get; private set; }

        public decimal Medie { get; private set; }

        public override string ToString()
        {
            return string.Format("{0,-20} - {1,4:0.00}", this.Nume, this.Medie);
        }
    }
}
