using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._05.DIP.Right
{
    internal class SMS : IMessage
    {
        public void SendMessage()
        {
            Console.WriteLine("SMS gönderildi.");
        }
    }
}
