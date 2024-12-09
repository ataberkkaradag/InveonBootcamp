using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMethodsAndAsyncAwait
{
    public class AsyncAwait
    {

        public void AddLog(string message)
        {
            HttpClient client = new HttpClient();
            client.PostAsync("https://www.gocasdvogle.com", new StringContent(message)).ContinueWith(responseMessage => {

                if (responseMessage.IsFaulted)
                {
                    Console.WriteLine("Error");
                }

                else
                {
                    var responseResult = responseMessage.Result;
                    if (!responseResult.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"İstek başarısız {responseResult.StatusCode}");
                    }
                    else
                    {
                        Console.WriteLine("log başarıyla gönderildi");
                    }

                }



            });
        }
    }
}
