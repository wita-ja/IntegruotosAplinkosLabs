using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace IntegruotuSistemuLaboratorinis3
{
  class PerfMeasuringUtils
  {
    public static void GenerateFullAndSortStudents_List(int numOfstudents)
    {
      Stopwatch timer = new Stopwatch();
      timer.Restart();

      List<Student> students = StudentUtils.GenerateStudentsFullConstructor_List(numOfstudents);
      StudentUtils.SortStudents_v0_4(students);

      timer.Stop();

      Console.WriteLine("Generation and dividing of random students by final score. " +
        $"Time elapsed: {timer.Elapsed}, students amount {numOfstudents}");
    }

    public static void TestPerformance_v0_4()
    {
      Console.WriteLine("Full Constructor");
      GenerateFullAndSortStudents_List(10_000);
      GenerateFullAndSortStudents_List(100_000);
      GenerateFullAndSortStudents_List(1_000_000);
      GenerateFullAndSortStudents_List(10_000_000);
    }
  }
}
