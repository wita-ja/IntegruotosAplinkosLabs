﻿using IntegruotuSistemuLaboratorinis3;
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
                            "1 - Add student\n" +
                            "2 - Print students to table\n" +
                            "3 - Import students from csv file\n" +
                            "4 - Generating and dividing students performance test\n" +
                            "5 - Generate csv files with students for performance testing\n" +
                            "6 - Measure performance of students sorting while using List, Linkedlist, Queue to store them\n" +
                            "7 - Measure performance of improved students sorting while using List, LinkedList, Queue to store them\n" +
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
              break;
            case 4:
              PerfMeasuringUtils.TestPerformance_v0_4();
              break;

            case 5:
              PerfMeasuringUtils.GenerateTestingFiles();
              break;

            case 6:
              PerfMeasuringUtils.TestCollectionsPerformance_v0_5();
              break;

            case 7:
              PerfMeasuringUtils.TestOptimizedSortingStrategies_v1_0();
              break;

            default:
              Console.WriteLine("Choice don't exists");
              break;
          }
        }
        catch (FormatException e)
        {
          Console.WriteLine($"{e.Message} Menu option are called only using numbers. Press Enter key to continue...");
        }
        Console.ReadLine();
      }
    }
  }
}
