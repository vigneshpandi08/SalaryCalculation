using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculation
{
    public class EmployeeSalary
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public double MonthlySalary { get; set; }
    }
    public class EmployeeBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string DateOfJoin { get; set; }
        public double AnnualSalary { get; set; }
        public string JobType { get; set; }
        public int HourlyRate { get; set; }
    }

    public class Employee : EmployeeBO
    {
        public Dictionary<int, EmployeeBO> emplist;
        public Employee()
        {
            emplist = new Dictionary<int, EmployeeBO>()
            {
            {1, new EmployeeBO { Name = "Ravi", Department = "Software Development", DateOfJoin = "02-Jan-2008", AnnualSalary = 480000, JobType = "Permanent"} } ,
            {2, new EmployeeBO { Name = "Ram Kumar", Department = "Software Development", DateOfJoin = "15-Mar-2010", HourlyRate=250, JobType = "Consultant"} } ,
            {3, new EmployeeBO { Name = "Arun", Department = "Web Development", DateOfJoin = "12-Feb-2012", AnnualSalary = 360000, JobType = "Permanent"} } ,
            {4, new EmployeeBO { Name = "Babu", Department = "Web Development", DateOfJoin = "05-May-2010", HourlyRate=200, JobType = "Consultant"} } ,
            {5, new EmployeeBO { Name = "Sarath", Department = "Designing", DateOfJoin = "15-Jun-2014", AnnualSalary = 420000, JobType = "Permanent"} } ,
            {6, new EmployeeBO { Name = "Prasath", Department = "Designing", DateOfJoin = "20-Aug-2015",HourlyRate=220, JobType = "Consultant"} } 

            };
        }
    }

    interface ICalculation
    {
        Dictionary<int, EmployeeSalary> CalculateMonthlySalary();
    }
    class Permanent : Employee, ICalculation
    {
        Dictionary<int, EmployeeSalary> permanentEmployees = new Dictionary<int, EmployeeSalary>();
        public Dictionary<int, EmployeeSalary> CalculateMonthlySalary()
        {
            foreach (int Id in emplist.Keys)
            {
                EmployeeBO emp = emplist[Id];
                if (emp.JobType == "Permanent")
                {
                    permanentEmployees.Add(Id, new EmployeeSalary()
                        {
                            EmpId = emp.Id,
                            EmpName = emp.Name,
                            MonthlySalary = emp.AnnualSalary / 12
                        }
                    );
                }
            }
            return permanentEmployees;
        }
    }
    class Consultant : Employee, ICalculation
    {
        Dictionary<int, EmployeeSalary> consultantEmployees = new Dictionary<int, EmployeeSalary>();
        public Dictionary<int, EmployeeSalary> CalculateMonthlySalary()
        {
            foreach (int Id in emplist.Keys)
            {
                EmployeeBO emp = emplist[Id];
                if (emp.JobType == "Consultant")
                {
                    consultantEmployees.Add(Id, new EmployeeSalary()
                    {
                        EmpId = emp.Id,
                        EmpName = emp.Name,
                        MonthlySalary = emp.HourlyRate * 8 * 20
                    }
                    );
                }
            }
            return consultantEmployees;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Permanent objPer = new Permanent();
            Dictionary<int, EmployeeSalary> monthlySalary = objPer.CalculateMonthlySalary();
            Console.WriteLine("\nPermanent Employee Details:");
            foreach(int id in monthlySalary.Keys)
            {
                EmployeeSalary empl = monthlySalary[id];
                Console.WriteLine("Monthly salary for" +" "+empl.EmpName +" "+ "is" +" " +empl.MonthlySalary);
            }

            Console.WriteLine("\nConsultant Employee Details:");
            Consultant objCon = new Consultant();
            monthlySalary = objCon.CalculateMonthlySalary();
            foreach (int id in monthlySalary.Keys)
            {
                EmployeeSalary empl = monthlySalary[id];
                Console.WriteLine("Monthly salary for" + " " + empl.EmpName + " " + "is" + " " + empl.MonthlySalary);
            }
            Console.ReadLine();
        }
    }
}
