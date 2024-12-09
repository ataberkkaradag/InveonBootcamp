using SRP.Models;
using SRP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    public class NotSingleRespUserService
    {

        SmsService smsService = new SmsService(); // Burada bağımlılık oluşturuluyor

        public void AuthenticateUser(string username, string password)
        {
            //Başka modulün kodunu kullanırsak o modüle bağımlı olur
        }
        public void UpdateUser(int Id, User userData)
        {
            smsService.SendSms();
        }

        public void SendNotificationEmail(string email, string message)
        {
            //Başka modulün kodunu kullanırsak o modüle bağımlı olur
        }
    }
}
