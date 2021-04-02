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
                            "3 - Import students from csv file\n" +
                            "0 - Exit.\n");

        Console.Write("Choose which task to run: ");
        userChoice = Console.ReadLine();
        try
        {
          switch (Convert.ToInt32(userChoice))
          {
            case 0:
              quit = true;
              break;

            case 1:
              students.Add(StudentUtils.CreateStudentFromConsole());
              break;

            case 2:
              StudentUtils.PrintInTable(students, true);
              break;
            case 3:
              string mainPath = @Environment.CurrentDirectory;
              students.AddRange(StudentUtils.ImportStudentsFromCsv(mainPath + "\\students.csv"));
              Console.WriteLine("Students where successfully imported. Press any key to continue...");
              break;
            default:
              Console.WriteLine("Choice don't exists");
              break;
          }

        }
        catch (FormatException e)
        {
          Console.WriteLine($"{e.Message} Menu option are called only using numbers. Press any key to continue...");
        }
        Console.ReadLine();
      }
    }
  }
}
