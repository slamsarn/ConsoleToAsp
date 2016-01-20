using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ClientConsole
{
    /// <summary>
    /// After reading this article http://stackoverflow.com/questions/15705092/do-httpclient-and-httpclienthandler-have-to-be-disposed,
    /// and the answer to the above article http://stackoverflow.com/questions/14075026/httpclient-crawling-results-in-memory-leak I made some changes.
    /// </summary>
    class Program
    {
        private readonly string url = "http://localhost:58301/Messages/RecievePostData";
        private string input = null;
        Task<HttpResponseMessage> response = null;

        static void Main(string[] args)
        {
            new Program().Start();
        }

        private void Start()
        {
            Console.WriteLine("Type 'exit' and press Enter to close application.");

            while (true)
            {
                using (var client = new HttpClient())
                {
                    Console.WriteLine();
                    Console.Write("Enter a message: ");
                    input = Console.ReadLine();

                    if (input == "exit")
                        Environment.Exit(0);

                    var inputValue = new Dictionary<string, string>() { { "msg", input } };

                    var content = new FormUrlEncodedContent(inputValue);

                    try
                    {
                        response = client.PostAsync(url, content);
                        response.Wait();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Something went wrong: " + Environment.NewLine + e.ToString());
                    }
                    finally
                    {
                        if (response.Result.IsSuccessStatusCode)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Message \"" + input + "\" uploaded to website successfully!");
                        }
                        else if (response.Result.StatusCode != System.Net.HttpStatusCode.OK)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Response message status code: " + Environment.NewLine + response.Result.StatusCode.ToString());
                        }
                    }
                }
            }
        }
    }
}
