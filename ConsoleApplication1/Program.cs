using System;
using System.Collections.Generic;
using System.Linq;
using Box.V2; 
using System.Text;
using System.Threading.Tasks;
using Box.V2.Config;
using Box.V2.Auth;
using Nito.AsyncEx;
using Box.V2.Models;
using Box.V2.Exceptions;
using System.ComponentModel;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CLIENT_ID = "mtohvlhbb3xd8z43a6u2zirvb1060tui";
            const string CLIENT_SECRET = "TdSrr7mFXtf6xEhdiJrRBiE2H1nnWGM6";
            const string DEV_ACCESS_TOKEN = "pZ5V4FmBJ4RXtaqdYQnS04Znuy71Yp7w";
            const string REFRESH_TOKEN = "helloworld";
            Console.WriteLine("Beginning");
            try
            {
                var config = new BoxConfig(CLIENT_ID, CLIENT_SECRET, new Uri("http://localhost"));
                var session = new OAuthSession(DEV_ACCESS_TOKEN, REFRESH_TOKEN, 3600, "bearer");
                var client = new BoxClient(config, session);

                AsyncContext.Run(() => MainAsync(client));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }

            Console.WriteLine();
            Console.Write("Press return to exit...");
            Console.ReadLine();

        }

        static async Task MainAsync(BoxClient client)
        {
            BoxFolder root = await client.FoldersManager.GetInformationAsync("0");
            // = new BoxUserRequest();
           
                // BoxUser user = await client.UsersManager.UpdateUserInformationAsync();

                List<string> fields = new List<string>();
                fields.Add("Name");
                BoxUser user2 = await client.UsersManager.GetCurrentUserInformationAsync(fields);
                foreach (var prop in user2.GetType().GetProperties())
                {
                    Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(user2, null));
                }
 //           await LoadFolder(root);
        }

    }
}
