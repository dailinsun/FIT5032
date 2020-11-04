using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChineseBridge.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void SendSingle(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("1020983834@qq.com", "Chinese Bridge User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }
        public void SendMultiple(List<string> toEmails, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("1020983834@qq.com", "Chinese Bridge User");
            List<EmailAddress> to = new List<EmailAddress>();
            for (int i = 0; i < toEmails.Count; i++)
            {
                to.Add(new EmailAddress(toEmails[i], ""));
            }
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }
    }
}