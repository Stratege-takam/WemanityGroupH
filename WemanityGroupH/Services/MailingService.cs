using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace WemanityGroupH.Services
{
   public class MailingService
    {
      
        public string FromName { get; set; }
        
        public string FromEmail { get; set; }

        public string ToName { get; set; }

        public string ToEmail { get; set; }
   
        public string Subject { get; set; }

        public bool IsHtmlTemplate { get; set; } = false;
  
        public string Body { get; set; }
       

        public string Smtp { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }
 
        public string Password { get; set; }



        public MailingService()
        {
            this.Smtp = "smtp.gmail.com";
            this.FromEmail = "dev.stratege@gmail.com";
            this.FromName = "Wemanity";
            this.Password = "Ryantakam1";
            this.UserName = "dev.stratege@gmail.com";
            this.Port = 587;
        }


        public void buildMail(MailMessage mailMessage)
        {

            MailAddress from = new MailAddress(FromEmail, FromName);
            mailMessage.From = from;

            MailAddress to = new MailAddress(ToEmail, ToName);
            mailMessage.To.Add(to);

            mailMessage.Subject = Subject;


            mailMessage.IsBodyHtml = IsHtmlTemplate;
            mailMessage.Body = Body;

        }


        public void SendMail(string toName, string toAddress, string subject, string body)
        {
            try
            {
                this.ToName = toName;
                this.ToEmail = toAddress;
                this.Subject = subject;
                this.IsHtmlTemplate = true;
                this.Body = body;
                using (var message = new MailMessage())
                {
                    buildMail(message);
                    using (var client = new SmtpClient("smtp.gmail.com"))
                    {
                        client.Port = this.Port;
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(this.UserName, this.Password);
                        client.Send(message);

                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

    }



}
