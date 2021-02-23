using System;

namespace IntegruotuSistemuLaboratorinis1
{
    class Program
    {
      
        static void Main(string[] args)
        {
            Tasks tasks = new Tasks();

            int userChoice;
            while(true)
            {
                Console.Clear();
                Console.WriteLine(tasks.Menu);
                Console.WriteLine("\nChoose which task to run \n");
                userChoice = Convert.ToInt32(Console.ReadLine());

                switch(userChoice)
                {
                    case 1: 
                        tasks.Uzd1();
                        break;
                    case 2:
                        tasks.Uzd2();
                        break;
                    case 3:
                        tasks.Uzd3();
                        break;
                    case 4:
                        tasks.Uzd4();
                        break;
                    case 5:
                        tasks.Uzd5();
                        break;
                    case 6:
                        tasks.Uzd6();
                        break;
                    case 7:
                        tasks.Uzd7();
                        break;
                    case 8:
                        tasks.Uzd8();
                        break;
                    case 9:
                        tasks.Uzd9();
                        break;
                    case 10:
                        tasks.Uzd10();
                        break;
                    case 11:
                        tasks.Uzd11();
                        break;
                    case 12:
                        tasks.Uzd12();
                        break;
                    case 13:
                        tasks.Uzd13();
                        break;
                    case 14:
                        tasks.Uzd14();
                        break;
                    default: Console.WriteLine("Choice don't exists");
                             break;
                }
                Console.ReadLine();
            }

           
        }

     
    }


}
