using CRUD.models;
using CRUD.repository;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                
                Repository repository = new Repository();
                Console.WriteLine("press a number");
                Console.WriteLine("1 : create user");
                Console.WriteLine("2 : all users");
                var inp = Console.ReadLine();
                switch (inp)
                {
                    case "1":
                        try
                        {
                            Console.Write("enter username : ");
                            var name = Console.ReadLine();
                            Console.Write("enter mobile number : ");
                            var mobile = Convert.ToDouble(Console.ReadLine());
                            Console.Write(@"enter user birthday by format -->00/00/0000 : ");
                            var bornDate = Console.ReadLine();
                            repository.Create(name, mobile, bornDate);
                            Console.WriteLine("ok");
                            Console.ReadKey();
                        }
                        catch
                        {
                            Console.WriteLine("the numbers is not corect");
                        }
                        Console.ReadKey();
                        break;
                    case "2":
                        List<string> list = repository.GetUsers();
                        Console.WriteLine("enter a number if you have delet or edit");
                        foreach (string user in list)
                        {
                            Console.WriteLine(user);
                        }
                        int.TryParse(Console.ReadLine(), out int id);
                        if (id > 0 && id<=repository.usersLenght())
                        {
                            Console.Write("1 : name \n2 : mobile \n3 : birthday \n" +
                                "enter a number you have edit that or enter d if you have delet user or e for exit : ");
                            string numberOfEdit = Console.ReadLine();
                            switch (numberOfEdit)
                            {

                                case "1":
                                    Console.Write("enter your edited : ");
                                    string nameEdited = Console.ReadLine();
                                    Console.WriteLine(repository.EditUser(id, 1, nameEdited));
                                    break;
                                case "2":
                                    Console.Write("enter your edited : ");
                                    string mobileEdited = Console.ReadLine();
                                    Console.WriteLine(repository.EditUser(id, 2, mobileEdited));
                                    break;
                                case "3":
                                    Console.Write("enter your edited : ");
                                    string dateEdited = Console.ReadLine();
                                    Console.WriteLine(repository.EditUser(id, 3, dateEdited));
                                    break;
                                case "d":
                                    Console.WriteLine(repository.RemoveById(id));
                                    break;
                                case "e":
                                    break;
                                default: Console.WriteLine("not corect please enter 1 or 2 or 3 or d"); break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("id is not corect plese try again");
                        }
                        Console.ReadKey();

                        break;
                    default: Console.WriteLine("not corect"); break;
                }
                Console.Clear();
            }
        }
    }
}