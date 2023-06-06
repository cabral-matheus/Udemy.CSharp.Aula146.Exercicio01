using System.Globalization;
using Udemy.CSharp.Aula146.Exercicio01.Entities;

namespace Udemy.CSharp.Aula146.Exercicio01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> taxPayers = new List<TaxPayer>();
            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c)? ");
                char option = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (option == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    taxPayers.Add(new Individual(healthExpenditures, name, anualIncome));

                } else if(option == 'c')
                {
                    Console.Write("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());
                    taxPayers.Add(new Company(numberOfEmployees, name, anualIncome));
                }

            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");
            double totalTaxes = 0.0;

            foreach(TaxPayer aux in taxPayers)
            {
                Console.WriteLine(aux);
                totalTaxes += aux.Tax();
            }

            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: $ " + totalTaxes.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}