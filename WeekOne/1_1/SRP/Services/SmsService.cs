﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Services
{
    public class SmsService : ISmsService
    {
        public void SendSms()
        {
            Console.WriteLine("Sms Gönderildi");
        }
    }
}