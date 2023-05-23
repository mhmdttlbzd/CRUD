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
            Repository repository = new Repository();
            repository.Create("mohamad", 09217470975, "30 / 01 / 1380");
            //User user = new User();


        }
    }
}