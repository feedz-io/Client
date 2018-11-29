using System;

namespace Feedz.Client.Logging
{
    public class ConsoleFeedLogger : IFeedzLogger
    {
        public void Info(string message)
            => Console.WriteLine(message);

        public void Error(string message)
            => Console.Error.WriteLine(message);
    }
}