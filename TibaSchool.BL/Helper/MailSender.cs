using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TibaSchool.BL.VModels;

namespace TibaSchool.BL.Helper
{
    public class MailSender
    {
		public static string SendMail(MailVM model)
		{
			try
			{
				var smtp = new SmtpClient("smtp.gmail.com", 587);
				smtp.EnableSsl = true;
				smtp.Credentials = new NetworkCredential("ahmed.selima95@gmail.com", "engjlcujratjyyks");
				string Body = $"Name: {model.Name} \nMail: {model.Email} \nPhone Number: {model.PhoneNumber} \nMessage: \n{model.Message} ";
				smtp.Send(model.Email,"ahmed.selima95@gmail.com",$"Email From {model.Name}",Body);				
				return "successful Operation";
			}
			catch (Exception ex)
			{

				return "Faild Operation";
			}
		}
	}
}
