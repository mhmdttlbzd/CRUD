using CRUD.models;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.repository
{
    internal class Repository
    {
        private List<User> users;
        public Repository()
        {
            using (var reader = new StreamReader("..\\..\\filePersons.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<User>();
                users = records.OrderBy(x => x.Id).ToList();
            }
        }
        public List<User> Create(string name, double mobile, string bornDate)
        {
            if (Convert.ToDateTime(bornDate) < DateTime.Now)
            {
                User user = new User();
                user.Name = name;
                user.Mobile = mobile;
                user.bornDate = Convert.ToDateTime(bornDate).Date;
                user.Id = 1;
                users.Add(user);
                WriteToCVR(users);
                return users;
            }
            else
            {
                throw new Exception("bord date is not corect");
            }
        }
        public void WriteToCVR(List<User> users)
        {
            using (var writer = new StreamWriter("..\\..\\filePersons.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(users);
            }
        }
    }
}
