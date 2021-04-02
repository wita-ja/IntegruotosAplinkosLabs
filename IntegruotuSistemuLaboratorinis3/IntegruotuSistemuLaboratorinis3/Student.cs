using System;
using System.Linq;
using System.Collections.Generic;

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

      return ((homeworkMedian* 0.3) + ExamResult * 0.7);
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
  }
}
