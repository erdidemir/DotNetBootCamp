using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._05.DIP.Wrong
{
    public class Notification
    {

        private Email email = new Email();
        private SMS sms = new SMS();

        public void sender()
        {

            email.sendEmail();
            sms.sendSMS();
        }

    }
}
