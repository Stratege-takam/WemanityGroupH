using System;
using WemanityGroupH.Services;

namespace WemanityGroupH
{
   public class Program
    {
        static void Main(string[] args)
        {
			try
			{
                var birthdayGreeterService = new BirthdayGreeterService()
                {
                    UserService = new UserService(),
                    MailingService = new MailingService()
                };

                birthdayGreeterService.GreetBirthdays();

                Console.WriteLine("End");
                Console.ReadLine();
            }
			catch (Exception e)
			{

				Console.WriteLine(e.Message);
			}
        }
    }
}
