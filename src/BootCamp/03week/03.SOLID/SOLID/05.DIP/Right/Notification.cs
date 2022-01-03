using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._05.DIP.Right
{
    internal class Notification
    {
        List<IMessage> Messages;
      
        public Notification(List<IMessage> Messages)
        {
            this.Messages = Messages;
        }

        public void Sender()
        {
            foreach(var message in Messages)
            {
                message.SendMessage();
            }
        }
    }
}
