using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTransit.Data.Models
{
    public class Users
    {
        public User[] Next { get; set; }
        public int Heigth { get; set; }
        private int _limit;
        private int index;
        public Users(int limit)
        {
            Next = new User[limit];
            _limit = limit;
            index = 0;
            Heigth = 0;
        }

        public void Add(UTransit.Models.User user)
        {
            lock (user)
            {
                if (Heigth > _limit - 1)
                {
                    if (index == _limit) { index = 0; }
                    Next[index].Add(user);
                    index++;
                }
                else
                {
                    Next[Heigth] = new User(1000);
                    Next[index].Add(user);
                    Heigth++;
                }
            }
        }
    }

    public class User
    {
        public User(int length)
        {
            Username = new string[length];
            Password = new string[length];
            Type = new string[length];
            IndexNumber = new string[length];
            Count = 0;
        }

        public int Count;
        public string[] Username;
        public string[] Password;
        public string[] Type;
        public string[] IndexNumber;

        public void Add(UTransit.Models.User user)
        {
            lock (user)
            {
                if(Count == Username.Length)
                {
                    var newLength = Username.Length + 1000;
                    var username = new string[newLength];
                    Username.CopyTo(username, 0);
                    Username = username;

                    var password = new string[newLength];
                    Password.CopyTo(password, 0);
                    Password = password;

                    var type = new string[newLength];
                    Type.CopyTo(type, 0);
                    Type = type;

                    var indexNumber = new string[newLength];
                    IndexNumber.CopyTo(indexNumber, 0);
                    IndexNumber = indexNumber;
                }

                Username[Count] = user.Username;
                Password[Count] = user.Password;
                Type[Count] = user.Type;
                IndexNumber[Count] = user.IndexNumber;
                Count++;
            }
        }
    }
}
