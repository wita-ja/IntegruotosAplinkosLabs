using System.Linq;
using System.Collections.Generic;
using System;

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
      double average = Homeworks.Average();
      double finalPoints = (average * 0.3) + (ExamResult * 0.7);
      return finalPoints;
    }

    public double CalcFinalPointsUsingMedian()
    {
      double homeworkMedian, finalPoints;
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
      return finalPoints = (homeworkMedian * 0.3) + (ExamResult * 0.7);
    }
  }
}