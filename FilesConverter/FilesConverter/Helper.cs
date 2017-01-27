using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FilesConverter.Result;
using FilesConverter.Rules;




namespace FilesConverter
{
    public static class Helper
    {
        public static void ChangeItemName(List<ExchangeRule> rules, List<IResultItem> convertedFile)
        {
            for (int i = 0; i < convertedFile.Count; i++)
            {
                foreach (var rule in rules)
                {
                    var currentName = convertedFile[i].ItemName;
                    if (currentName.Contains(rule.OldName))
                    {
                        convertedFile[i].ItemName = string.IsNullOrEmpty(currentName.Substring(rule.OldName.Length)) ? rule.NewName : rule.NewName + currentName.Substring(rule.OldName.Length);
                        break;
                    }
                }
            }
        }

        public static bool IsRowEmpty(DataRow row)
        {
            return row.ItemArray.All(item => item == DBNull.Value);
        }

        public static void SetColumnsInDataTable(DataTable dtTable)
        {

            for (int i = 0; i < dtTable.Rows[0].ItemArray.Length; i++)
            {
                dtTable.Columns[i].ColumnName = dtTable.Columns.Contains(dtTable.Rows[0].ItemArray[i].ToString()) ? dtTable.Rows[0].ItemArray[i].ToString() + 1 : dtTable.Rows[0].ItemArray[i].ToString();
            }
            DataRow rowDel = dtTable.Rows[0];
            dtTable.Rows.Remove(rowDel);
        }

        public static void email_send(string subject, string filePath)
        {
            try
            {
                var mail = new MailMessage();
                mail.IsBodyHtml = true;
                var smtpServer = new SmtpClient("post.morion.ua");
                mail.From = new MailAddress("snizhana.nomirovska@proximaresearch.com");
                mail.To.Add("snizhana.nomirovska@proximaresearch.com");
                mail.To.Add("sneghkan@i.ua");
                mail.Subject = subject;
                Attachment attachment = new Attachment(filePath);
                mail.Attachments.Add(attachment);
                mail.Body = "";
                smtpServer.Send(mail);
            }
            catch (Exception)
            {
                
               
            }
            
        }

    }
}
