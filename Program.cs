using System;
using System.Globalization;

namespace Calculator_CS
{
    class Program
    {
        // Citeste un numar. Intoarce false daca utilizatorul apasa doar Enter (iesire).
        static bool CitesteNumar(string mesaj, out double numar)
        {
            while (true)
            {
                Console.Write(mesaj);
                string text = (Console.ReadLine() ?? "").Trim();
                if (text == "")
                {
                    numar = 0;
                    return false;
                }

                // Acceptam si virgula, si punctul ca separator zecimal
                text = text.Replace(',', '.');
                if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out numar))
                    return true;

                Console.WriteLine("Eroare: introduceti un numar valid.");
            }
        }

        // Citeste operatia pana cand este una dintre cele permise
        static string CitesteOperatia()
        {
            while (true)
            {
                Console.Write("Operatia (+, -): ");
                string op = (Console.ReadLine() ?? "").Trim();
                if (op == "+" || op == "-")
                    return op;
                Console.WriteLine("Eroare: operatie necunoscuta.");
            }
        }

        static void Afiseaza(double a, string op, double b, double rezultat)
        {
            Console.WriteLine($"Rezultat: {a} {op} {b} = {rezultat}");
        }

        static void Main()
        {
            Console.WriteLine("=== Calculator-CS ===");
            Console.WriteLine("(apasati Enter la \"Primul numar\" pentru iesire)");

            while (true)
            {
                if (!CitesteNumar("Primul numar: ", out double a))
                    break;

                string op = CitesteOperatia();

                if (!CitesteNumar("Al doilea numar: ", out double b))
                    break;

                switch (op)
                {
                    case "+":
                        Afiseaza(a, op, b, a + b);
                        break;
                    case "-":
                        Afiseaza(a, op, b, a - b);
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("La revedere!");
        }
    }
}
