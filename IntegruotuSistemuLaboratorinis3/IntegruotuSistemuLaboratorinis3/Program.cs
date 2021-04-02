using IntegruotuSistemuLaboratorinis3;
using System;
using System.Collections.Generic;

namespace IntegruotuAplinkuLaboratorinis3
{
  class Program
  {
    static void Main(string[] args)
    {
      var students = new List<Student>();

      string userChoice;
      bool quit = false;
      while (quit == false)
      {
        Console.Clear();
        Console.WriteLine("\n       Menu\n" +
                            "1 - Add student.\n" +
                            "2 - Print students to table\n" +
                            "3 - Import students from csv file" +
                            "0 - Exit.\n");

        Console.Write("Choose which task to run: ");
        userChoice = Console.ReadLine();
        switch (Convert.ToInt32(userChoice))
        {
          case 0:
            quit = true;
            break;

          case 1:
            while (true)
            {
              Console.Write("Auto generate marks? y/n: ");

              userChoice = Console.ReadLine();
              if (userChoice == "y" || userChoice == "Y")
              {
                Console.Write("How many homeworks to generate: ");
                userChoice = Console.ReadLine();

                if (Convert.ToInt32(userChoice) > 0)
                {
                  students.Add(HandlingStudentInput(true, Convert.ToInt32(userChoice)));
                  break;
                }
                else
                {
                  Console.WriteLine("The mark must be positive integer. Please try again");
                  continue;
                }
              }
              else if (userChoice == "n" || userChoice == "N")
              {
                students.Add(HandlingStudentInput(false));
              }
              break;
            }
            break;

          case 2:
            Student.PrintInTable(students, true);
            break;
          case 3:
            string mainPath = @Environment.CurrentDirectory;
            students = Student.ImportStudentsFromCsv(mainPath + "\\students.csv");
            Console.WriteLine("Students where successfully imported. Press any key to continue");
            break;
          default:
            Console.WriteLine("Choice don't exists");
            break;
        }
        Console.ReadLine();
      }
    }

    static Student HandlingStudentInput(bool generateMarks, int homeworkCount = 0)
    {
      var newStudent = new Student();
      var homeworks = new List<int>();
      Console.Write("Input Student name: ");
      newStudent.Name = Console.ReadLine();

      Console.Write("Input Student surname: ");
      newStudent.Surname = Console.ReadLine();

      if (generateMarks)
      {
        Random random = new Random();
        for (int i = 0; i < homeworkCount; i++) homeworks.Add(random.Next(1, 10));
        homeworks.Sort();
        newStudent.Homeworks = homeworks;
        newStudent.ExamResult = random.Next(1, 10);
      }
      else
      {
        int userMarksInput;
        while (true)
        {
          Console.Write("Enter Student homework marks(enter 0 to quit): ");
          try
          {
            userMarksInput = Convert.ToInt32(Console.ReadLine());
            if (userMarksInput == 0) break;
            if (userMarksInput < 1 || userMarksInput > 10)
            {
              Console.WriteLine("The mark must be integer from 1-10 range. Please try again");
              continue;
            }
            homeworks.Add(userMarksInput);
          }
          catch (Exception e)
          {
            Console.WriteLine($"{e.Message} Please try again.");
            continue;
          }
        }
        newStudent.Homeworks = homeworks;

        while (true)
        {
          Console.Write("Enter Student exam mark: ");
          try
          {
            userMarksInput = Convert.ToInt32(Console.ReadLine());
            if (userMarksInput < 1 || userMarksInput > 10)
            {
              Console.WriteLine("The mark must be integer from 1-10 range. Please try again");
              continue;
            }
            newStudent.ExamResult = userMarksInput;
          }
          catch (Exception e)
          {
            Console.WriteLine($"{e.Message} Please try again.");
            continue;
          }
          break;
        }
      }

      return newStudent;
    }
  }
}
