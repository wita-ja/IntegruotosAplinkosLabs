using System;
using System.Linq;


namespace IntegruotuSistemuLaboratorinis1
{
    class Program
    {
        public void Uzd1()
        {
            int n;
            // pradine reiksme reikejo prideti =1, pakeiciau double i int nes faktorialas yra sveikas skaicius
            int f= 1;
            Console.WriteLine("1st task - nth number factorial");
            Console.WriteLine("Enter a positive number N:");
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++) // int i = 1
            {
                f *= i;
            }

            Console.WriteLine("{0}!={1}", n, f);
        }

        public void Uzd2()
        {
            int n;
            int sum = 0;
            double average;
            Console.WriteLine("2nd task - average of n entered values");
            Console.WriteLine("Enter a number of values:");
            n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter values:");
            for (int i = 0; i < n; i++)
            {
                sum += Convert.ToInt32(Console.ReadLine());
            }
            average = (double)sum / n;
            
            Console.WriteLine("Entered numbers average is equal to {0}", average);
        }

        public void Uzd3()
        {
            int n = int.MaxValue;
            int count = 0;

            Console.WriteLine("3rd task - First five positive odd number squares");
            for (int i = 1; i<n; i++)
            {
                if(count==5)
                {
                    break;
                }
                else if ( i % 2 != 0)
                {
                    Console.WriteLine("Number: {0}, Square: {1}",i, i * i);
                    count++;
                }
            }
        }

        public void Uzd4()
        {
            int userChoice;
            double areaOfShape = 0;
            int width, height, lowerBase, upperBase;

            Console.WriteLine("4th task - area of shape(rectangular,  triangular  or  trapezoidal) calculation");
            Console.WriteLine("Choose shape \n 1 - rectangular \n 2 - triangular \n 3 - trapezoidal");
            userChoice = Convert.ToInt32(Console.ReadLine());

            switch(userChoice)
            {
                case 1:
                    Console.WriteLine("Your choice - rectangular");
                    Console.WriteLine("Enter width:");
                    width = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter height:");
                    height = Convert.ToInt32(Console.ReadLine());
                    areaOfShape = width * height;
                    break;
                case 2:
                    Console.WriteLine("Your choice - triangular");
                    Console.WriteLine("Enter base:");
                    lowerBase = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter vertical height:");
                     height = Convert.ToInt32(Console.ReadLine());
                    areaOfShape = 0.5 * lowerBase * height;
                    break;
                case 3:
                    Console.WriteLine("Your choice - trapezoidal");
                    Console.WriteLine("Enter lower base:");
                    lowerBase = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter upper base:");
                    upperBase = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter vertical height:");
                    height = Convert.ToInt32(Console.ReadLine());
                    areaOfShape = 0.5*(lowerBase + upperBase) * height;
                    break;
                default:
                    Console.WriteLine("Unsupported option");
                    break;
            }
            Console.WriteLine("Area of choosen shape is {0}", areaOfShape);
        }

        public void Uzd5()
        {
            char symbol;
            Console.WriteLine("5th task - identify type of simbol (number/lowercase letter/uppercase letter/non letter");
            Console.WriteLine("Enter the symbol");
            symbol = Console.ReadLine()[0];

            if (char.IsNumber(symbol))
            {
                Console.WriteLine("Your symbol is a number - {0}", symbol);
            }
            else if (char.IsLower(symbol))
            {
                Console.WriteLine("Your symbol is a lowercase letter - {0}", symbol);
            }
            else if (char.IsUpper(symbol))
            {
                Console.WriteLine("Your symbol is a uppercase letter - {0}", symbol);
            }
            /*else if (!char.IsLetter(symbol))
            {
                Console.WriteLine("You entered not a letter - {0}", symbol);
            }*/
            else Console.WriteLine("Your symbol is not a letter - {0}", symbol);
        }

        public void Uzd6()
        {
            Console.WriteLine("6th task - identify errors in cycle");
            int i = 1; //type nebuvo
            while (i < 10)
            {
                int j = i * i - 1; //type truko
                int k = 2 * j - 1; //type truko
                Console.WriteLine("i={0}; j={1}; k={2}", i, j, k);
                i++; //neikrementuojamas i todel gaudavosi begalinis ciklas
            }
        }

        public void Uzd7()
        {
            Console.WriteLine("7th task - output values of y = -2.4 * x^2 + 5 * x - 3 by step 0.5 where x from -2 to 2 \n Answer");

            double y = 0;
            double x = -2;
            while(x<=2)
            {
                y = (-2.4 * Math.Pow(x, 2)) + (5 * x - 3);
                Console.WriteLine("x = {0}, y = {1}", x, y);
                x += 0.5;
            }
        }

        public void Uzd8()
        {
            Console.WriteLine("8th task - output ASCII codes for a-z");

            //ASCII lowercase simboliai eina nuo 97 iki 122
            for (int i = 97; i <= 122; i++) 
            {
                Console.WriteLine("letter - {0}, ASCII code - {1}", (char)i, i);
            }

        }

        public void Uzd9()
        {
            //Prime number is a number that is greater than 1 and divided by 1 or itself. 
            Console.WriteLine("9th task - determine if entered number is prime");

            int number;
            Console.WriteLine("Enter number:");
            number = Convert.ToInt32(Console.ReadLine());

            if (number == 0 || number == 1)
            {
                Console.WriteLine(number + " is not prime number");
            }
            else
            {
                for (int a = 2; a <= number / 2; a++)
                {
                    if (number % a == 0)
                    {
                        Console.WriteLine(number + " is not prime number");
                        break;
                    }

                }
                Console.WriteLine(number + " is a prime number");
            }
        }

        public void Uzd10()
        {
            Console.WriteLine("10th task - number [1;10] guessing game");
            Random random = new Random();
            int randomNumber = random.Next(1, 11);
            int guessedNumber;
            for (int i = 4; i >= 0; i--)
            {
                Console.WriteLine("Enter your guess");
                guessedNumber = Convert.ToInt32(Console.ReadLine());

                if (guessedNumber == randomNumber) {
                    Console.WriteLine("You won!! your guess {0}, randomNumber was {1}", guessedNumber, randomNumber);
                    break;
                }
                else if (i == 0) Console.WriteLine("You Lose. all five attemps are used... Your guessed {0}, randomNumber was {1}", guessedNumber, randomNumber);
                else Console.WriteLine("Luck is not on your side this time. You have {0} more attemps", i);
            }
        }

        public void Uzd11()
        {
//TODO
        }

        public void Uzd12()
        {
           
            Console.WriteLine("12th task - biggest common divisor of two entered numbers");

            Console.WriteLine("Enter first number");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number");
            int num2 = Convert.ToInt32(Console.ReadLine());

            //Euclid's algorithm
            while (num2 !=0)
            {
                int temp = num2;
                num2 = num1 % num2;
                num1 = temp;
            }

            Console.WriteLine("greatest common divisor {0}", num1);

        }

        public void Uzd13()
        {
            Console.WriteLine("13th task - count digits number in a string");

            Console.WriteLine("Enter your string");
            string characters = Console.ReadLine();
           
            for (int i = 1; i < 10; i++)
            {
                int count = 0;
                for(int j= 0; j < characters.Length; j++)
                { 
                    if (char.IsDigit(characters[j]))
                    {
                        int temp = int.Parse((characters[j].ToString()));
                        if ( temp == i)
                        {
                            count++;
                        }
                    }
                }
                Console.WriteLine(i + " is repeated " + count + " times in your string " + characters);
            }
        }

        public void Uzd14()
        {
            Console.WriteLine("14th task - guessing game with Vilnius date");
            Random random = new Random();
            int answer = 1323;
            int guessedNumber;
            for (int i = 2; i >= 0; i--)
            {
                Console.WriteLine("What is the official Vilnius founding year?");
                guessedNumber = Convert.ToInt32(Console.ReadLine());

                if (guessedNumber == answer)
                {
                    Console.WriteLine("You won!! your guess {0}, Vilnius foundation year is {1}", guessedNumber, answer);
                    break;
                }
                else if (i == 0) Console.WriteLine("You miss, Vilnius founding year is {1}", guessedNumber, answer);
                else Console.WriteLine("Luck is not on your side this time. You have {0} more attemps", i);
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            program.Uzd14();
        }
    }
}
