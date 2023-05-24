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
    public class Repository
    {
        private List<User> users;
        public Repository()
        {
            try 
            {
                using (var reader = new StreamReader("..\\..\\FileDataStorage.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<User>();
                    users = records.OrderBy(x => x.Id).ToList();
                }
            }
            catch
            {
                FileStream f = new FileStream("e:..\\..\\FileDataStorage.csv", FileMode.Create);
                f.Close();
            }

        }
        public bool Create(string name, double mobile, string bornDate)
        {
            if (Convert.ToDateTime(bornDate) < DateTime.Now)
            {
                User user = new User();
                user.Name = name;
                user.Mobile = mobile;
                user.bornDate = Convert.ToDateTime(bornDate).Date;
                if (users.Count()==0)
                {
                    user.Id = 1;
                }
                else
                {
                    user.Id = 1 + users.Last().Id;
                }
                users.Add(user);
                WriteToCVR(users);
                return true;
            }
            else
            {
                throw new Exception("born date is not corect");
            }
        }
        public List<string> GetUsers()
        {
            List<string> showUsers = new List<string>();
            foreach (var user in users)
            {
                showUsers.Add(user.Id.ToString()+ " : "+ user.Name+" - "+user.Mobile.ToString() + " - "+ user.bornDate.ToString());
            }
            return showUsers;
        }
        public bool RemoveById(int id)
        {
            if (users.Count()!=0)
            {
                foreach (User u in users)
                {
                    if (u.Id == id)
                    {
                        users.Remove(u); break;
                    }
                }
                WriteToCVR(users);
                return true;
            }
            return false;
        }
        public int usersLenght()
        {
            return users.Last().Id;
        }
        public bool EditUser(int id , int num ,string edited)
        {
            if (users.Count() != 0)
            {
                try
                {
                    foreach (User user in users)
                    {
                        if (user.Id == id)
                        {
                            switch (num)
                            {
                                case 1:
                                    user.Name = edited;
                                    return true;
                                case 2:
                                    user.Mobile = Convert.ToDouble(edited);
                                    return true;
                                case 3:
                                    user.bornDate = Convert.ToDateTime(edited);
                                    return true;
                            }
                        }
                    }
                }
                catch
                {
                    throw new Exception("the number is not corect");
                }
            }
            return false;
        }
        private void WriteToCVR(List<User> users)
        {
            using (var writer = new StreamWriter("..\\..\\FileDataStorage.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(users);
            }
        }
    }
}
