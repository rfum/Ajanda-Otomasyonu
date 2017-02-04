using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Windows.Forms;

namespace ajanda
{
    class mail
    {
        public static string eposta(string msg,string yol)
    {
        SmtpClient client = new SmtpClient();
        MailMessage mesaj = new MailMessage();
        client.EnableSsl = false;
        client.Host = "pop.mynet.com";
        client.Port = 587;
        client.Credentials = new System.Net.NetworkCredential("axaxaxaxaxax@mynet.com","123456789");
        mesaj.To.Add(new MailAddress("axaxaxaxaxax@mynet.com"));
        mesaj.From = new MailAddress("axaxaxaxaxax@mynet.com");
        mesaj.Body = msg;
        mesaj.Attachments.Add(new Attachment(@yol));
        mesaj.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        client.Send(mesaj);
        MessageBox.Show("mesaj gönderildi");
        
            


        return msg;

    }
    }
}
