using System;
using System.Collections.Generic;
using System.Text;

namespace IntegruotuSistemuLaboratorinis2
{
  class Application
  {
    static void Main(string[] args)
    {
      string mainPath = @Environment.CurrentDirectory;
      BusinessPartners bussinesPartners = new BusinessPartners();

      //Setting initial companies
      bussinesPartners.ImportCompaniesFromCsv(mainPath + "\\companiesList.csv");

      int userChoice;
      bool quit = false;
      while (quit == false)
      {
        Console.Clear();
        Console.WriteLine("\n Companies list");
        foreach (Company company in bussinesPartners.Companies)
        {
          Console.WriteLine($" {company.Name}, {company.DirectorSurname}, {company.NumOfEmployees}, {company.City}, {company.PhoneNumber}\n");
        }

        Console.WriteLine("\n Menu\n" +
                            " 1 - Calculate average number of employees in all companies.\n" +
                            " 2 - Export companies filtered by company name and city.\n" +
                            " 3 - Export companies filtered by company name, director surname and city.\n" +
                            " 0 - Exit.\n");

        Console.Write(" Choose which task to run: ");
        userChoice = Convert.ToInt32(Console.ReadLine());
        string companyName, companyDirectorSurname, companyCity;
        List<Company> filteredCompanies;
        switch (userChoice)
        {
          case 1:
            Console.WriteLine($"Average number is {bussinesPartners.AvgEmployeeNumPerCompany()}");
            break;
          case 2:
            Console.Write(" Enter company name: ");
            companyName = Console.ReadLine();
            Console.Write(" Enter company city: ");
            companyCity = Console.ReadLine();

            Console.WriteLine("\n Filtered companies list");
            filteredCompanies = bussinesPartners.FilterCompanies(companyName, companyCity);
            
            foreach (Company company in filteredCompanies)
            {
              Console.WriteLine($" {company.Name}, {company.DirectorSurname}, {company.NumOfEmployees}, {company.City}, {company.PhoneNumber}\n");
            }

            bussinesPartners.ExportToCsvFile(filteredCompanies, "FilteredByNameAndCity");
            Console.WriteLine(" Export was successful!");
            break;
          case 3:
            Console.Write(" Enter company name: ");
            companyName = Console.ReadLine();
            Console.Write(" Enter company director surname: ");
            companyDirectorSurname = Console.ReadLine();
            Console.Write(" Enter company city: ");
            companyCity = Console.ReadLine();

            Console.WriteLine("\n Filtered companies list");
            filteredCompanies = bussinesPartners.FilterCompanies(companyName, companyCity, companyDirectorSurname);

            foreach (Company company in filteredCompanies)
            {
              Console.WriteLine($" {company.Name}, {company.DirectorSurname}, {company.NumOfEmployees}, {company.City}, {company.PhoneNumber}\n");
            }

            bussinesPartners.ExportToCsvFile(filteredCompanies, "FilteredByNameAndDirectorSurnameAndCity");
            Console.WriteLine(" Export was successful!");
            break;
          case 0:
            quit = true;
            break;
          default:
            Console.WriteLine("Choice don't exists");
            break;
        }
        Console.ReadLine();
      }
    }
  }
}
