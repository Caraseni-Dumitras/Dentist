// using System.Net.Mail;
//
// namespace Application.Services;
//
// public class EmailService : IEmailService
// {
//     
//     public async Task SendEmailAsync(string email, string subject, string htmlMessage)
//     {
//         var client = new SmtpClient("localhost", 25); // or 2525
//         var message = new MailMessage
//         {
//             From = new MailAddress("test@example.com"),
//             Subject = subject,
//             Body = htmlMessage,
//             IsBodyHtml = true
//         };
//         message.To.Add(email);
//
//         await client.SendMailAsync(message);
//     }
// }
//
// public class EmailConfiguration
// {
//     public string SmtpServer { get; set; }
//     public int Port { get; set; }
//     public string Username { get; set; }
//     public string Password { get; set; }
//     public string FromAddress { get; set; }
// }