using System;

namespace Lab3CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("lab 3. Choose task: ");
            Console.WriteLine("1. Task 1");
            Console.WriteLine("2. Task 2");
            Console.WriteLine("3. Exit");

            int choice;
            bool isValidChoice = false;

            do
            {
                Console.Write("Enter number of task: ");
                isValidChoice = int.TryParse(Console.ReadLine(), out choice);

                if (!isValidChoice || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Error: Invalid choice!");
                    isValidChoice = false;
                }
            } while (!isValidChoice);

            switch (choice)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }

        static void Task1()
        {
            object[,] arr = new object[4, 3]
            {
              {10, 10, "black"},
              {11, 10, "black"},
              {12, 12, "black"},
              {13, 13, "black"}
            };

            for (int i = 0; i < 4; i++)
            {
                Rectangle r = new Rectangle(Convert.ToInt32(arr[i, 0]), Convert.ToInt32(arr[i, 1]), arr[i,2].ToString());
                Console.WriteLine(r.GetSideA());
                Console.WriteLine(r.GetSideB());
                Console.WriteLine(r.Area());
                Console.WriteLine(r.Perimeter());
                Console.WriteLine(r.IsSquare());
                Console.WriteLine("-------");
            }
        }

        static void Task2()
        {
            Republic republic = new Republic()
            {
                Name = "Ukraine",
                Population = 40000000,
                Area = 603000,
                President = "Volodymyr Zelensky"
            };

            Monarchy monarchy = new Monarchy()
            {
                Name = "United Kingdom",
                Population = 67000000,
                Area = 242495,
                Monarch = "Queen Elizabeth II"
            };

            Kingdom kingdom = new Kingdom()
            {
                Name = "Sweden",
                Population = 10000000,
                Area = 450295,
                Monarch = "King Carl XVI Gustaf",
                NobilityCount = 8000
            };

            republic.Show();
            Console.WriteLine();
            monarchy.Show();
            Console.WriteLine();
            kingdom.Show();
        }

        public class Rectangle
        {
            private int sideA, sideB;
            private string color;

            public Rectangle(int sideA, int sideB, string color)
            {
                this.sideA = sideA;
                this.sideB = sideB;
                this.color = color;
            }

            public int GetSideA()
            {
                return sideA;
            }

            public int GetSideB()
            {
                return sideB;
            }

            public int Area()
            {
                return sideA * sideB;
            }

            public int Perimeter()
            {
                return (sideA + sideB) * 2;
            }

            public bool IsSquare()
            {
                return sideA == sideB;
            }
        }

        class Country
        {
            public string Name { get; set; }
            public int Population { get; set; }
            public double Area { get; set; }

            public virtual void Show()
            {
                Console.WriteLine($"Country: {Name}");
                Console.WriteLine($"Population: {Population}");
                Console.WriteLine($"Area: {Area}");
            }
        }

        class Republic : Country
        {
            public string President { get; set; }

            public override void Show()
            {
                base.Show();
                Console.WriteLine($"President: {President}");
            }
        }

        class Monarchy : Country
        {
            public string Monarch { get; set; }

            public override void Show()
            {
                base.Show();
                Console.WriteLine($"Monarch: {Monarch}");
            }
        }

        class Kingdom : Monarchy
        {
            public int NobilityCount { get; set; }

            public override void Show()
            {
                base.Show();
                Console.WriteLine($"Nobility Count: {NobilityCount}");
            }
        }
    }
}
