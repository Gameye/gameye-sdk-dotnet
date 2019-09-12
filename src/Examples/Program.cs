using System;

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
            var botmatch = new BotMatch();
            botmatch.Run().Wait();
        }
    }
}
