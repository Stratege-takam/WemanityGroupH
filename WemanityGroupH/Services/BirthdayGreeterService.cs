using System;
using System.Collections.Generic;
using System.Text;

namespace WemanityGroupH.Services
{
  public  class BirthdayGreeterService
    {
        private UserService UserService { get; set; }
        private MailingService MailingService { get; set; }
        private const string _mailTemplate = "Happy Birthday, dear {firstname}!";
        private const string _subject = "Happy birthday!";

       public void GreetBirthdays()
        {
            foreach (var user in UserService.Users)
            {
                if (user.BirthDate.Date.Equals( DateTime.Now.Date))
                {
                    MailingService.SendMail($"{user.Firstname} {user.Lastname}", user.Mail,
                        _subject, _mailTemplate.Replace("{firstname}", user.Firstname));
                }
            }
        }
    }
}
