using SRP.Models;
using SRP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    public class SingleRespUserService
    {
        private readonly ISmsService _smsService;

        public SingleRespUserService(ISmsService smsService) //Doğrudan kullanmak yerine bağımlılığı dışarıdan aldık
        {
            _smsService = smsService;

        }
        public void UpdateUser(int Id, User userData)
        {
            _smsService.SendSms();
        }
    }
}
