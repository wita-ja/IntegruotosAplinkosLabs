using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IntegruotuSistemuLaboratorinis2
{
  class BusinessPartners
  {
    private List<Company> companies;

    public BusinessPartners() {}

    public BusinessPartners(List<Company> companies)
    {
      this.companies = companies;
    }
    public List<Company> Companies { get => companies; set => companies = value; }

    public double AvgEmployeeNumPerCompany ()
    {
      double empSum = 0;
      foreach (Company company in companies)
      {
        empSum += company.NumOfEmployees;
      }
      return empSum / companies.Count;
    }

    public List<Company> FilterCompanies(string companyName, string companyCity)
    {
      List<Company> filteredList = new List<Company>();
      companies.ForEach(company => {
        if (company.Name == companyName && company.City == companyCity)
        {
          filteredList.Add(company);
        }
      });

      return filteredList;
    }

    public List<Company> FilterCompanies(string companyName, string companyCity, string companyDirectorSurname)
    {
      List<Company> filteredList = new List<Company>();
      companies.ForEach(company => {
        if (company.Name == companyName && company.DirectorSurname == companyDirectorSurname && company.City == companyCity)
        {
          filteredList.Add(company);
        }
      });

      return filteredList;
    }

    public void ImportCompaniesFromCsv(string fileName)
    {
      try
      {
        List<Company> companyList = File.ReadAllLines(fileName)
                .Skip(1)
                .Select(line => line.Split(","))
                .Select(values => new Company(values[0], values[1], values[2], int.Parse(values[3]), values[4]))
                .ToList();
        Companies = companyList;

      }
      catch (FileNotFoundException e)
      {
        Console.WriteLine(e.ToString());
      }

    }
    public string ExportToCsvFile(string fileName)
    {
      var csvFile = new StringBuilder();

      csvFile.AppendLine("Name,DirectorSurname,NumOfEmployees,City,PhoneNumber");

      companies.ForEach(company => csvFile.AppendLine($"{company.Name},{company.DirectorSurname},{company.NumOfEmployees},{company.City},{company.PhoneNumber}"));

      File.WriteAllText(fileName + ".csv", csvFile.ToString());

      return csvFile.ToString();
    }
    public string ExportToCsvFile(List<Company> companies, string fileName)
    {
      var csvFile = new StringBuilder();

      csvFile.AppendLine("Name,DirectorSurname,NumOfEmployees,City,PhoneNumber");

      companies.ForEach(company => csvFile.AppendLine($"{company.Name},{company.DirectorSurname},{company.NumOfEmployees},{company.City},{company.PhoneNumber}"));

      File.WriteAllText(fileName + ".csv", csvFile.ToString());

      return csvFile.ToString();
    }
  }
}
