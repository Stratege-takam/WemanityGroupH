using System;
using System.Collections.Generic;
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
                         BirthDate = new DateTime(1982,10,8),
                         Mail = "pkriwin@wemanity.com"
                    },
                     new User()
                    {
                         Lastname ="Takam",
                         Firstname = "Danick",
                         BirthDate = new DateTime(1979,12,12),
                         Mail = "213346@supinfo.com"
                    },
                      new User()
                    {
                         Lastname ="Te",
                         Firstname = "Emmanuelle",
                         BirthDate = new DateTime(2005,2,31),
                         Mail = "297192@supinfo.com"
                    }
                };
        }
        public void ReadFromFileAsync()
        {
            
            return null;
        }
    }
}
