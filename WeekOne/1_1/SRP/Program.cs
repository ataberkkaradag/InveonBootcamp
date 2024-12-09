// See https://aka.ms/new-console-template for more information
using SRP;
using SRP.Models;
using SRP.Services;

Console.WriteLine("Hello, World!");





// UserProfileService SRP ye uyumlu UserService SRP ye uyumsuz örnektir 

NotSingleRespUserService notSingleRespUserService = new NotSingleRespUserService();
ISmsService smsService = new SmsService();
SingleRespUserService singleRespUserService = new SingleRespUserService(smsService);
User user = new User { Id = 1, Email = "asd", Password = "1234", Username = "Inveon" };

notSingleRespUserService.AuthenticateUser("Inveon", "12345");

notSingleRespUserService.SendNotificationEmail("Inveon@gmail.com", "Inveon");

notSingleRespUserService.UpdateUser(1, user);

singleRespUserService.UpdateUser(1, user);

Console.ReadLine();
