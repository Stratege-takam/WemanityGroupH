using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WemanityGroupH.Models;

namespace WemanityGroupH.Services
{
   public class UserService
    {
        public List<User> Users { get; set; }
        public UserService()
        {
                Users = new List<User>()
                {
                    new User()
                    {
                         Lastname ="Doe",
                         Firstname = "John",
                         BirthDate = new DateTime(2019,12,17),
                         Mail = "pkriwin@wemanity.com"
                    },
                     new User()
                    {
                         Lastname ="Takam",
                         Firstname = "Danick",
                         BirthDate = new DateTime(2019,12,17),
                         Mail = "213346@supinfo.com"
                    },
                      new User()
                    {
                         Lastname ="Te",
                         Firstname = "Emmanuel",
                         BirthDate = new DateTime(2019,12,17),
                         Mail = "297192@supinfo.com"
                    }
                };
        }
        public void ReadFromFileAsync(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                Users = JsonConvert.DeserializeObject<List<User>>(json);
            }
        }
    }
}
