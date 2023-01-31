using HighSchool.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Transactions;

namespace HighSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {

            HighSchoolContext Context = new HighSchoolContext();


            bool MenuActive = true;

            while (MenuActive == true)
            {
                Console.Clear();
                Console.WriteLine("School Menu:\n1. See all Students\n2. " +
                "See all Students in a certain Class\n3. Add new staff\n4. Exit");
                string MenuChoice = Console.ReadLine();


                switch (MenuChoice)
                {

                    case "1":
                        SeeAllStudents(Context);
                        break;
                    case "2":
                        CertainClass(Context);
                        break;
                    case "3":
                        NewStaff(Context);
                        break;
                    case "4":
                        MenuActive = false;
                        break;
                    case "5":
                        RemoveMethod(Context); // Manuell Removal
                        break;
                    default:
                        Console.WriteLine("Choose between 1-4");
                        break;
                }
            }

            static void SeeAllStudents(HighSchoolContext Context)
            {
                Console.Clear();
                Console.WriteLine("How do you want to see the students:");
                Console.WriteLine("1. First name ascending\n2. First name descending" +
                "\n3. Last name ascending\n4. Last name descending");
                string Choice = Console.ReadLine();

                if (Choice == "1")
                {
                    Console.Clear();
                    var Stu = Context.Students.OrderBy(s => s.Fname);

                    foreach (Student item in Stu)
                    {
                        Console.WriteLine($"ID: {item.Id} Name: {item.Fname}");
                    }
                    Console.ReadKey();
                }
                else if (Choice == "2")
                {
                    Console.Clear();
                    var Stu = Context.Students.OrderByDescending(s => s.Fname);

                    foreach (Student item in Stu)
                    {
                        Console.WriteLine($"ID: {item.Id} Name: {item.Fname}");
                    }
                    Console.Read();
                }
                else if (Choice == "3")
                {
                    Console.Clear();
                    var Stu = Context.Students.OrderBy(s => s.Lname);

                    foreach (Student item in Stu)
                    {
                        Console.WriteLine($"ID: {item.Id} Name: {item.Lname}");
                    }
                    Console.Read();
                }
                else if (Choice == "4")
                {
                    Console.Clear();
                    var Stu = Context.Students.OrderByDescending(s => s.Lname);

                    foreach (Student item in Stu)
                    {
                        Console.WriteLine($"ID: {item.Id} Name: {item.Lname}");
                    }
                    Console.Read();
                }
                else
                {
                    Console.WriteLine("Choose between 1-4");
                }
            }

            static void CertainClass(HighSchoolContext Context)
            {

                Console.Clear();
                Console.WriteLine("All available classes");

                var Cla = Context.Classes.OrderBy(c => c.Id);
                foreach (Class item in Cla)
                {
                    Console.WriteLine(item.Id + ". " + item.Class1);
                }

                Console.WriteLine("Choose the Number of the class where you want to see the students in:");
                int.TryParse(Console.ReadLine(), out int Choice);

                var StuCla = Context.StudentClasses.Where(c => c.ClassId == Choice).Select(s => s.Student);//.ToList();
                //var Stu = Context.Students.Where(s => StuCla.Contains(s.Id));//.ToList();

                Console.WriteLine($"Students in {Context.Classes.FirstOrDefault(x => x.Id == Choice).Class1}");

                foreach (var item in StuCla)
                {
                    Console.WriteLine(item.Id + ". " + item.Fname + " " + item.Lname);
                }
                Console.ReadKey();

            }
            static void NewStaff(HighSchoolContext Context)
            {
                Console.Clear();
                Console.WriteLine("Which type of Staff would you like to add?");
                var Role = Context.staff;
                foreach (var item in Role)
                {
                    Console.WriteLine(item.Id + "." + item.Role);
                }
                int.TryParse(Console.ReadLine(), out int Staff);

                Console.WriteLine("Enter the firstname:");
                var fName = Console.ReadLine();
                Console.WriteLine("Enter the last name:");
                var lName = Console.ReadLine();
                Console.WriteLine("Enter your Adress");
                var Adress = Console.ReadLine();
                Console.WriteLine("Enter PhoneNumber:");
                int.TryParse(Console.ReadLine(), out int Phone);

                if (Staff == 1 || Staff == 2)
                {
                    Context.PrincipleAdmins.Add(new PrincipleAdmin { Fname = fName, Lname = lName, StaffId = Staff, Id = 4 });
                }
                else if (Staff == 3)
                {
                    Context.Teachers.Add(new Teacher { Fname = fName, Lname = lName, StaffId = Staff, Adress = Adress, Phone = Phone });
                }

                Context.SaveChanges();

                Console.WriteLine("The staff has been added\nPress any button to Exit to main Menu");
                Console.ReadLine();
            }
        }

        private static void RemoveMethod(HighSchoolContext Context)
        {

            var teach = Context.PrincipleAdmins
                .Where(t => t.Fname == "Damir").FirstOrDefault();

            if (teach is PrincipleAdmin)
            {
                Context.Remove(teach);
            }

            Context.SaveChanges();

            Console.WriteLine("Deleted");

            Console.ReadKey();
        }
    }
}

