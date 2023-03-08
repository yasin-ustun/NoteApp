using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Service
{
    public class MailService
    {
        public static void SendMail()
        {
           

            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("info@ustunsoft.com");
            //
            ePosta.To.Add("bm.yasinustun@gmail.com");
            //
            //ePosta.Attachments.Add(new Attachment(@"C:\deneme-upload.jpg"));
            //
            ePosta.Subject = "Deneme";
            //
            ePosta.Body = "İlk Mail";
            //

            SmtpClient smtp = new SmtpClient();
            //
            smtp.Credentials = new System.Net.NetworkCredential(ePosta.From.Address, "^E0wo4a6", "ustunsoft.com");

            smtp.Port = 25;
            smtp.Host = "mail.ustunsoft.com";
            smtp.EnableSsl = true;

            object userState = ePosta;
            bool kontrol = true;

            try
            {
                smtp.Send(ePosta);
                //smtp.SendAsync(ePosta, (object)ePosta);
            }
            catch (SmtpException ex)
            {
                throw ex;
                //kontrol = false;
                //System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }
        }
    }
}
