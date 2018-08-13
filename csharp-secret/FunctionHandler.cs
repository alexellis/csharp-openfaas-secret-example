using System;
using System.Text;
using System.IO;

namespace Function
{
    public class FunctionHandler
    {
        public void Handle(string input) {

            var key = getSecret("api-key");

            var headerAuth = System.Environment.GetEnvironmentVariable("Http_Authorization");

            if(headerAuth == null || headerAuth != "Bearer " + key) {
                Console.WriteLine("unauthorized");
                Environment.Exit(1);
            }

            Console.WriteLine("Authorized.. OK");
        }

        private string getSecret(string file) {
            return File.ReadAllText("/var/openfaas/secrets/" + file).Trim();
        }
    }
}
