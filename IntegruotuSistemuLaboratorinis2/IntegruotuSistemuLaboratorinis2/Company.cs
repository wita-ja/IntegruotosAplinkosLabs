using System;
using System.Collections.Generic;
using System.Text;

namespace IntegruotuSistemuLaboratorinis2
{
  class Company
  {
    private string name;
    private string directorSurname;
    private string city;
    private int numOfEmployees;
    private string phoneNumber;

    public Company() {}
    public Company(string name, string directorSurname, string city, int numOfEmployees, string phoneNumber)
    {
      this.name = name;
      this.directorSurname = directorSurname;
      this.city = city;
      this.numOfEmployees = numOfEmployees;
      this.phoneNumber = phoneNumber;
    }

    public string Name { get => name; set => name = value; }
    public string DirectorSurname { get => directorSurname; set => directorSurname = value; }
    public string City { get => city; set => city = value; }
    public int NumOfEmployees { get => numOfEmployees; set => numOfEmployees = value; }
    public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

  }
}
