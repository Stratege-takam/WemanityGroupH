using System;
using WemanityGroupH.Services;

namespace WemanityGroupH
{
   public class Program
    {
        static void Main(string[] args)
        {

            MailingService mailingService = new MailingService();

            //send Mail
            mailingService.SendMail("Test name", "pkriwin@wemanity.com", "Test subject", "<h1>Test body</h1>");

            Console.WriteLine("Hello World!");
        }
    }
}
