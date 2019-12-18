using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WemanityGroupH.Models;

namespace WemanityGroupH.Services
{
  public  class BirthdayGreeterService
    {
        public UserService UserService { get; set; }
        public MailingService MailingService { get; set; }

        private const string _mailTemplate = "Happy Birthday, dear {firstname}!";
        private const string _mailTemplateRemember = "Dear <firstname>,<p>Today is <allfullname>'s birthday. <br/> Don't forget to send them a message !</p>";
        private const string _subject = "Happy birthday!";

       public void GreetBirthdays()
       {
            var greetUsers = UserService.Users.Where(user => IsGreetBirthdays(user)).ToList();
            foreach (var user in greetUsers)
            {
                MailingService.SendMail($"{user.Firstname} {user.Lastname}", user.Mail,
                         _subject, _mailTemplate.Replace("{firstname}", user.Firstname));
            }

            RememberBirthdays(greetUsers);
       }

        public void RememberBirthdays(List<User> users)
        {
            var ListFullname = users?.Select((user, i) => 
                    i == users.Count -1 ?
                        $"{user.Firstname} {user.Lastname}" : 
                    i == users.Count - 2 ?
                        $"{user.Firstname} {user.Lastname} and " :
                        $"{user.Firstname} {user.Lastname}, " 
                );
            if (ListFullname !=null)
            {
                MailingService.SendMail(MailingService.FromName, MailingService.FromEmail,
                         _subject, _mailTemplateRemember
                         .Replace("<firstname>", MailingService.FromName)
                         .Replace("<allfullname>", string.Join("",ListFullname)));
            }
        }

       public bool IsGreetBirthdays(User user)
       {
            return (user.BirthDate.Date.Equals(DateTime.Now.Date)
                        && !IsLastDayOfFebruary(user.BirthDate.Date)) ||
                        IsLastDayOfFebruary(user.BirthDate.Date);
       }

        private bool IsLastDayOfFebruary(DateTime date)
        {
            return date.Month == 2 && date.Day == 29 &&  DateTime.Now.Day == 28;
        }
    }
}
