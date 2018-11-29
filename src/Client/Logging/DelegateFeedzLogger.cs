using System;

namespace Feedz.Client.Logging
{
    public class DelegateFeedzLogger : IFeedzLogger
    {
        private readonly Action<string> _info;
        private readonly Action<string> _error;

        public DelegateFeedzLogger(Action<string> info, Action<string> error)
        {
            _info = info;
            _error = error;
        }
        
        public void Info(string message) => _info(message);
        public void Error(string message) => _error(message);
    }
}