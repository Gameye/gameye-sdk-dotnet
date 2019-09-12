using Gameye.Sdk;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples
{
    class Program
    {
        class MenuItem
        {
            public string Message { get; set; }
            public Action Action { get; set; }
        }

        static void Main(string[] args)
        {
            var config = new GameyeClientConfig("https://api.gameye.org");
            var client = new GameyeClient(config);

            var items = new Dictionary<char, MenuItem>
            {
                {
                    '1',
                    new MenuItem
                    {
                        Message = "Start a bot Match",
                        Action = async () => {
                            await client.CommandStartMatch(Guid.NewGuid().ToString(),
                                "csgo-dem",
                                new[] { "frankfurt" },
                                "bots",
                                new Dictionary<string,object> {{ "maxRounds", 2 }});
                        }
                    }
                },
                {
                    '2',
                    new MenuItem
                    {
                        Message = "Listen to Session Events",
                        Action = async () => { await client.SubscribeSessionEvents(); }
                    }
                },
                {
                    '3',
                    new MenuItem
                    {
                        Message = "Listen to Statistics",
                        Action = async () => { await client.SubscribeStatisticsEvents(); }
                    }
                }

            };


            char readKey = ' ';
            while(readKey != 'q')
            {
                Console.Clear();
                Console.WriteLine("Choose an action");
                foreach(var menuItem in items)
                {
                    Console.WriteLine($"{menuItem.Key}. {menuItem.Value.Message}");
                }

                readKey = Console.ReadKey().KeyChar;
                if (items.ContainsKey(readKey))
                {
                    try
                    {
                        items[readKey].Action();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.StackTrace);
                    }
                }
            }
        }
    }
}
