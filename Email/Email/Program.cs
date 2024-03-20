using System.Net;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Enter your email address:");
string emailAddress = Console.ReadLine();
if (!IsValidEmail(emailAddress))
{
    Console.WriteLine("Please provide a valid email address");
    return;
}
if (SendEmail(emailAddress))
{
    Console.WriteLine("Email snet successfully");
}
else
{
    Console.WriteLine("Email failed to send");
}

static bool IsValidEmail(string email)
{
    try
    {
        MailAddress mail = new MailAddress(email);
        return mail.Address == email;
    }
    catch
    {
        return false;
    }
}

static bool SendEmail(string emailAddress)
{
    try
    {
        using (MailMessage mailMessage = new MailMessage())
        {
            mailMessage.From = new MailAddress("raresamza@gmail.com");
            mailMessage.To.Add(emailAddress);

            mailMessage.Subject = "Thanks for subbing to our newsletter";
            mailMessage.Body = "Thank you for subscribing to our newsletter.\nWe are delighted by the fact that you are interested in our products and want to stay up to date with everything we do\n.Thank you!";

            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
            {
                smtpClient.Credentials = new NetworkCredential("raresamza@gmail.com", "qygs zndu mbqh sjrs");
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
            }
        }
        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error occured: {ex.Message}");
        return false;
    }
}