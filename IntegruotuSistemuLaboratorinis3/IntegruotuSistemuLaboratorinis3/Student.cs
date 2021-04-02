using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace IntegruotuSistemuLaboratorinis3
{
  class Student
  {
    private string name;
    private string surname;
    private List<int> homeworks;
    private int examResult;

    public Student() { }
    public Student(string name, string surname, List<int> homeworks, int examResult)
    {
      this.name = name;
      this.surname = surname;
      this.homeworks = homeworks;
      this.examResult = examResult;
    }

    public string Name { get => name; set => name = value; }
    public string Surname { get => surname; set => surname = value; }
    public List<int> Homeworks { get => homeworks; set => homeworks = value; }
    public int ExamResult { get => examResult; set => examResult = value; }

    public double CalcFinalPointsUsingAvg()
    {
      return ((Homeworks.Average() * 0.3) + ExamResult * 0.7);
    }

    public double CalcFinalPointsUsingMedian()
    {
      double homeworkMedian;

      int numberCount = Homeworks.Count();
      int halfIndex = Homeworks.Count() / 2;
      var sortedNumbers = Homeworks.OrderBy(n => n);

      if ((numberCount % 2) == 0)
      {
        homeworkMedian = ((sortedNumbers.ElementAt(halfIndex) +
            sortedNumbers.ElementAt((halfIndex - 1))) / 2);
      }
      else
      {
        homeworkMedian = sortedNumbers.ElementAt(halfIndex);
      }

      return ((homeworkMedian * 0.3) + ExamResult * 0.7);
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

      for (int i = 2; i <= values.Length - 1; i++)
      {
        int currval = Convert.ToInt32(values[i]);
        if (currval < 1 || currval > 10)
        {
          throw new ArgumentOutOfRangeException(nameof(currval), $"Integer is out of allowed range (1-10).");
        }
        else homeworks.Add(currval);
      }
      return new Student(values[0], values[1], homeworks, Convert.ToInt32(values[7]));
    }
  }
}


