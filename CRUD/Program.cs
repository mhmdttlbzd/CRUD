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
                            var mobile = int.Parse(Console.ReadLine());
                            Console.Write(@"enter user birthday by format -->00 \ 00 \ 0000 : ");
                            var bornDate = Console.ReadLine();
                            repository.Create(name, mobile, bornDate);
                        }
                        catch
                        {
                            Console.WriteLine("the numbers is not corect");
                        }

                        break;
                    case "2":

                        break;
                }

            }



        }
    }
}