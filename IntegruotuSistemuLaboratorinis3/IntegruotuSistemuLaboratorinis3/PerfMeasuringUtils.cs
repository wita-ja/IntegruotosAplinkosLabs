using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace IntegruotuSistemuLaboratorinis3
{
  class PerfMeasuringUtils
  {
    private static Student[] students10k, students100k, students1M, students10M;
    private static Student[] Students10k { get => students10k; set => students10k = value; }
    private static Student[] Students100k { get => students100k; set => students100k = value; }
    private static Student[] Students1M { get => students1M; set => students1M = value; }
    private static Student[] Students10M { get => students10M; set => students10M = value; }

    private const string csvHeader = "Name,Surname,HW1,HW2,HW3,HW4,HW5,Exam";
    public static void GenerateAndSortStudents(int numOfstudents)
    {
      Stopwatch timer = new Stopwatch();
      timer.Restart();

      List<Student> students = StudentUtils.GenerateStudentsList(numOfstudents);
      SortStudents(students);

      timer.Stop();

      Console.WriteLine("Generation and dividing of random students by final score. " +
        $"Time elapsed: {timer.Elapsed}, students amount {numOfstudents}");
    }

    public static void SortStudents(List<Student> students)
    {
      int numOfStudents = students.Count();
      StreamWriter passedStudentsList = new StreamWriter($"passed_students_list_{numOfStudents}.csv");
      StreamWriter failedStudentsList = new StreamWriter($"failed_students_list_{numOfStudents}.csv");

      passedStudentsList.WriteLine(csvHeader);
      failedStudentsList.WriteLine(csvHeader);

      foreach (Student student in students)
      {
        if (student.CalcFinalPointsUsingAvg() >= 5)
          passedStudentsList.WriteLine(StudentUtils.StudentToCsvString(student));
        else failedStudentsList.WriteLine(StudentUtils.StudentToCsvString(student));
      }

      passedStudentsList.Close();
      failedStudentsList.Close();
    }

    public static void SortStudents(LinkedList<Student> students)
    {
      int numOfStudents = students.Count();
      StreamWriter passedStudentsList = new StreamWriter($"passed_students_Linkedlist_{numOfStudents}.csv");
      StreamWriter failedStudentsList = new StreamWriter($"failed_students_Linkedlist_{numOfStudents}.csv");

      passedStudentsList.WriteLine(csvHeader);
      failedStudentsList.WriteLine(csvHeader);

      foreach (Student student in students)
      {
        if (student.CalcFinalPointsUsingAvg() >= 5)
          passedStudentsList.WriteLine(StudentUtils.StudentToCsvString(student));
        else failedStudentsList.WriteLine(StudentUtils.StudentToCsvString(student));
      }

      passedStudentsList.Close();
      failedStudentsList.Close();
    }

    public static void SortStudents(Queue<Student> students)
    {
      int numOfStudents = students.Count();
      StreamWriter passedStudentsList = new StreamWriter($"passed_students_Queue_{numOfStudents}.csv");
      StreamWriter failedStudentsList = new StreamWriter($"failed_students_Queue_{numOfStudents}.csv");

      passedStudentsList.WriteLine(csvHeader);
      failedStudentsList.WriteLine(csvHeader);

      foreach (Student student in students)
      {
        if (student.CalcFinalPointsUsingAvg() >= 5)
          passedStudentsList.WriteLine(StudentUtils.StudentToCsvString(student));
        else failedStudentsList.WriteLine(StudentUtils.StudentToCsvString(student));
      }

      passedStudentsList.Close();
      failedStudentsList.Close();
    }
    
    public static void MeasureSort(Student[] studentsArray, string collection)
    {
      Stopwatch timer = new Stopwatch();
      switch (collection)
      {
        case "List":
          List<Student> studentsList = new List<Student>(studentsArray);
          timer.Restart();
          SortStudents(studentsList);
          timer.Stop();
          Console.WriteLine("Sorting of random students by final score using List.       " +
           $"Time elapsed: {timer.Elapsed}, students amount {studentsArray.Length}");
          break;
        case "Linkedlist":
          LinkedList<Student> studentsLinkedlist = new LinkedList<Student>(studentsArray);
          timer.Restart();
          SortStudents(studentsLinkedlist);
          timer.Stop();
          Console.WriteLine("Sorting of random students by final score using LinkedList. " +
           $"Time elapsed: {timer.Elapsed}, students amount {studentsArray.Length}");
          break;
        case "Queue":
          Queue<Student> studentsQueue = new Queue<Student>(studentsArray);
          timer.Restart();
          SortStudents(studentsQueue);
          timer.Stop();
          Console.WriteLine("Sorting of random students by final score using Queue.      " +
           $"Time elapsed: {timer.Elapsed}, students amount {studentsArray.Length}");
          break;
        default:
          Console.WriteLine("Wrong collection Id");
          break;
      }
    }

    public static void TestPerformance_v0_4()
    {
      GenerateAndSortStudents(10_000);
      GenerateAndSortStudents(100_000);
      GenerateAndSortStudents(1_000_000);
      GenerateAndSortStudents(10_000_000);
      Console.WriteLine("\nTesting finished. Press any key to continue...");
    }

    public static void TestCollectionsPerformance_v0_5()
    {
      ImportStudentsFromTestingFiles();

      MeasureSort(Students10k, "List");
      MeasureSort(Students10k, "Linkedlist");
      MeasureSort(Students10k, "Queue");
      Console.WriteLine("\n");

      MeasureSort(Students100k, "List");
      MeasureSort(Students100k, "Linkedlist");
      MeasureSort(Students100k, "Queue");
      Console.WriteLine("\n");

      MeasureSort(Students1M, "List");
      MeasureSort(Students1M, "Linkedlist");
      MeasureSort(Students1M, "Queue");
      Console.WriteLine("\n");

      MeasureSort(Students10M, "List");
      MeasureSort(Students10M, "Linkedlist");
      MeasureSort(Students10M, "Queue"); 
      Console.WriteLine("\nTesting finished. Press any key to continue...");
    }

    public static void GenerateTestingFiles()
    {
      Console.WriteLine("Testing files are being generated. Please wait");
      StudentUtils.GenerateStudentsToCSVFile(1_0000);
      StudentUtils.GenerateStudentsToCSVFile(100_000);
      StudentUtils.GenerateStudentsToCSVFile(1_000_000);
      StudentUtils.GenerateStudentsToCSVFile(10_000_000);
      Console.WriteLine("\nTesting files were successfully generated. Press any key to continue...");
    }

    public static void ImportStudentsFromTestingFiles()
    {
      Console.WriteLine("Importing students for testing");

      string filename;

      filename = @Environment.CurrentDirectory + $"/students_{10_000}.csv";
      Students10k = StudentUtils.ImportStudentsFromCsv(filename).ToArray();

      filename = @Environment.CurrentDirectory + $"/students_{1_000_00}.csv";
      Students100k = StudentUtils.ImportStudentsFromCsv(filename).ToArray();

      filename = @Environment.CurrentDirectory + $"/students_{1_000_000}.csv";
      Students1M = StudentUtils.ImportStudentsFromCsv(filename).ToArray();


      filename = @Environment.CurrentDirectory + $"/students_{10_000_000}.csv";
      Students10M = StudentUtils.ImportStudentsFromCsv(filename).ToArray();

      Console.WriteLine("\nFinished importing students for testing");
    }
  }
}
