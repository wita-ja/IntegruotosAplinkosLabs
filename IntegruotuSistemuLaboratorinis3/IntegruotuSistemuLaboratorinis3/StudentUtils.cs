using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IntegruotuSistemuLaboratorinis3
{
  class StudentUtils
  {
    public static Student CreateStudentFromConsole()
    {
      string userChoice;
      Student createdStudent;
      while (true)
      {
        Console.Write("Auto generate marks? y/n: ");

        userChoice = Console.ReadLine();
        if (userChoice == "y" || userChoice == "Y")
        {
          try
          {
            Console.Write("How many homeworks to generate: ");
            userChoice = Console.ReadLine();
            if (Convert.ToInt32(userChoice) > 0)
            {
              createdStudent = HandlingStudentDataInput(true, Convert.ToInt32(userChoice));
              break;
            }
            else
            {
              Console.WriteLine("The mark must be positive integer. Please try again");
              continue;
            }
          }
          catch (FormatException e)
          {
            Console.WriteLine($"\n {e.Message} \nHomeworks number must be integer\n");
            continue;
          }
        }
        else if (userChoice == "n" || userChoice == "N")
        {
          createdStudent = HandlingStudentDataInput(false);
          break;
        }
        else Console.WriteLine("Not valid answer. Should be 'y' to agree or 'n' to disagree. Please try again");
      }
      Console.WriteLine("Student was successfully created. Press any key to continue...");
      return createdStudent;
    }
    private static Student HandlingStudentDataInput(bool generateMarks, int homeworkCount = 0)
    {
      var tempStudent = new Student();
      var homeworks = new List<int>();

      Console.Write("Input Student name: ");
      tempStudent.Name = Console.ReadLine();

      Console.Write("Input Student surname: ");
      tempStudent.Surname = Console.ReadLine();

      if (generateMarks)
      {
        Random random = new Random();

        for (int i = 0; i < homeworkCount; i++) homeworks.Add(random.Next(1, 10));
        homeworks.Sort();

        tempStudent.Homeworks = homeworks;
        tempStudent.ExamResult = random.Next(1, 10);
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
          catch (FormatException e)
          {
            Console.WriteLine($"{e.Message} Please try again.");
            continue;
          }
        }
        tempStudent.Homeworks = homeworks;

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
            tempStudent.ExamResult = userMarksInput;
          }
          catch (FormatException e)
          {
            Console.WriteLine($"{e.Message} Please try again.");
            continue;
          }
          break;
        }
      }

      return tempStudent;
    }


    public static void PrintInTable(List<Student> students, bool median)
    {
      students = students.OrderBy(student => student.Name).ToList();
      string line = "----------------------------------------------------------------------------------------------";

      Console.Write('\n');
      if (median == false)
      {
        Console.WriteLine("{0, -30} {1, -20} {2, -5}", "Surname", "Name", "Final points (Avg.)");
        Console.Write(line);
        Console.Write('\n');

        students.ForEach(student =>
        {
          Console.WriteLine("{0, -30} {1, -20} {2, -5:#.##}", student.Surname, student.Name, student.CalcFinalPointsUsingAvg());
        });
        Console.WriteLine("Press any key to continue...");
      }
      else
      {
        Console.WriteLine("{0, -30} {1, -20} {2, -5}", "Surname", "Name", "Final points (Avg.) / Final points (Med.)");
        Console.Write(line);
        Console.Write('\n');

        students.ForEach(student =>
        {
          Console.WriteLine("{0, -30} {1, -20} {2, -21:#.##} {3, -20:#.##}", student.Surname, student.Name, student.CalcFinalPointsUsingAvg(), student.CalcFinalPointsUsingMedian());
        });
        Console.WriteLine("Press any key to continue...");
      }
    }

    public static List<Student> ImportStudentsFromCsv(string fileName)
    {
      List<Student> students = new List<Student>();
      try
      {
        students = File.ReadAllLines(fileName)
                .Skip(1)
                .Select(line => line.Split(","))
                .Select(values => StudentFromCsvString(values))
                .ToList();
      }
      catch (FileNotFoundException e)
      {
        Console.WriteLine(e.ToString());
      }
      return students;
    }

    private static Student StudentFromCsvString(string[] values)
    {
      List<int> homeworks = new List<int>();

      for (int i = 2; i < 7; i++)
      {
        int currval = Convert.ToInt32(values[i]);
        if (currval < 1 || currval > 10)
        {
          throw new ArgumentOutOfRangeException(nameof(currval), $"Integer is out of allowed range (1-10).");
        }
        else homeworks.Add(currval);
      }
      homeworks.Sort();
      return new Student(values[0], values[1], homeworks, Convert.ToInt32(values[7]));
    }
  }
}
