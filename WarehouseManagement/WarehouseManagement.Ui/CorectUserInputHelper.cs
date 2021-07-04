using System;

namespace WarehouseManagement.Ui
{
    public class CorectUserInputHelper
    {
        public string GetUserStringInput(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public double GetUserDoubleInput(string question)
        {           

            // te tiesam var ievadit dalskaitli?

            return Convert.ToDouble(GetUserIntInput(question));
        }

        public short GetUserShortInput(string question)
        {
            Console.WriteLine(question);

            // vajag gudrak tapat ka int

            return short.Parse(Console.ReadLine());
        }

        public int GetUserIntInput(string question)
        {
            int userNumber;
            Console.WriteLine(question);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out userNumber))
                {
                    break;
                }
                Console.WriteLine("That was not a number, please write a number!");
            }
              
            return Math.Abs(userNumber);
        }
    }
}
