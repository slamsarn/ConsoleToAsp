using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }

        private void Start()
        {
            Console.WriteLine("Type 'exit' and press Enter to close application.");
            Console.WriteLine();
            string url = "http://localhost:58301/Messages/RecievePostData";
            string input = null;
            var client = new HttpClient();
            while (true)
            {
                Console.Write("Enter a message: ");
                input = Console.ReadLine();

                if (input == "exit")
                    Environment.Exit(0);

                var inputValue = new Dictionary<string, string>() { { "msg", input } };

                var content = new FormUrlEncodedContent(inputValue);

                var response = client.PostAsync(url, content);
                response.Wait();
                
                client.Dispose();
            }
        }
    }
}
