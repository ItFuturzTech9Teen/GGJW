using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace GGJWEvent.Models
{
    public class SendSMS
    {
        public void SendSms()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string GetSMSBalanceForBulkSms(string url)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 1000; //Timeout after 1000 ms
                using (var stream = request.GetResponse().GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string res = reader.ReadToEnd();
                    return res;
                }
            }
            catch (Exception)
            {
                return "FAIL";
            }
            return "";
        }

        public string fun_sendsms(string Vmessage, string Vmobno)
        {
            DataTable dt = GetSMSSettings();
            if (dt.Rows.Count == 0)
                return null;
            string Username = dt.Rows[0]["UserId"].ToString();
            string Password = dt.Rows[0]["Pswd"].ToString();
            string SenderId = dt.Rows[0]["SenderId"].ToString();

            //string outputBuffer = "where=46038";
            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://suratsms.dnsitexperts.com/smsapi.aspx?username=dnsitexe&password=dns@123&sender=STUDYF&to=" + Vmobno + "&message=" + Vmessage + "&route=route3");



            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://bulksms.dnsitexperts.com/sendsms.jsp?user=" + Username + "&password=" + Password + "&mobiles=" + Vmobno + "&senderid=" + SenderId + "&sms=" + Vmessage + "");

            //req.Method = "POST";
            //req.ContentLength = outputBuffer.Length;
            //req.ContentType = "application/x-www-form-urlencoded";
            //StreamWriter swOut = new StreamWriter(req.GetRequestStream());
            //swOut.Write(outputBuffer);
            //swOut.Close();
            //HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            //StreamReader sr = new StreamReader(resp.GetResponseStream());
            //string buffer = sr.ReadToEnd();
            string buffer = "";
            buffer = GetSMSBalanceForBulkSms("http://bulksms.dnsitexperts.com/sendsms.jsp?user=" + Username + "&password=" + Password + "&mobiles=" + Vmobno + "&senderid=" + SenderId + "&sms=" + Vmessage + "");
            return buffer;
        }

        public string sendotp(string Vmessage, string Vmobno)
        {
            string outputBuffer = "where=46038";
            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://bulksms.itfuturz.com/api/sendmsg.php?priority=ndnd&stype=normal&user=progressclub&pass=dns@123&sender=PRCLUB&phone=" + Vmobno + "&text=" + Vmessage + "");
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://promosms.itfuturz.com/vendorsms/pushsms.aspx?user=prclub&password=dns123&msisdn=" + Vmobno + "&sid=PRCLUB&msg=" + Vmessage + "&fl=0&gwid=2");

            req.Method = "POST";
            req.ContentLength = outputBuffer.Length;
            req.ContentType = "application/x-www-form-urlencoded";
            StreamWriter swOut = new StreamWriter(req.GetRequestStream());
            swOut.Write(outputBuffer);
            swOut.Close();
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string buffer = sr.ReadToEnd();

            buffer = buffer.Replace("\r", "");
            buffer = buffer.Replace("\n", "");
            //string res = "";
            if (buffer.Contains("error") || buffer.Contains("Invalid") || buffer == null)
            {
                return "not ok";
            }
            else if (buffer.Contains("1 SMS Sent"))
            {
                return "ok";
            }
            else if (buffer.Contains("sent,success"))
            {
                return "ok";
            }
            else if (buffer.Contains("S."))
            {
                return "ok";
            }
            else if (buffer.Contains("Send Successful"))
            {
                return "ok";
            }
            else if (buffer.Length == 9)
            {
                return "ok";
            }
            else if (buffer.Contains("No balance"))
            {
                return "Insufficient SMS Balance";
            }
            else
            {
                return "ok";
            }
        }

        public string sendotpPetPalace(string Vmessage, string Vmobno)
        {
            string outputBuffer = "where=46038";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://suratsms.dnsitexperts.com/smsapi.aspx?unicode=1&username=petpalace&password=petpalace&sender=PETPLC&to=" + Vmobno + "&message=" + Vmessage + "&route=route3");
            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://bulksms.dnsitexperts.com/sendsms.jsp?user=" + Username + "&password=" + Password + "&mobiles=" + Vmobno + "&senderid=" + SenderId + "&sms=" + Vmessage + "");

            req.Method = "POST";
            req.ContentLength = outputBuffer.Length;
            req.ContentType = "application/x-www-form-urlencoded";
            StreamWriter swOut = new StreamWriter(req.GetRequestStream());
            swOut.Write(outputBuffer);
            swOut.Close();
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string buffer = sr.ReadToEnd();

            buffer = buffer.Replace("\r", "");
            buffer = buffer.Replace("\n", "");
            //string res = "";
            if (buffer.Contains("error") || buffer.Contains("Invalid") || buffer == null)
            {
                return "not ok";
            }
            else if (buffer.Contains("1 SMS Sent"))
            {
                return "ok";
            }
            else if (buffer.Contains("sent,success"))
            {
                return "ok";
            }
            else if (buffer.Contains("S."))
            {
                return "ok";
            }
            else if (buffer.Contains("Send Successful"))
            {
                return "ok";
            }
            else if (buffer.Length == 9)
            {
                return "ok";
            }
            else
            {
                return "ok";
            }

        }

        public string fun_ScheduleSMS(string Vmessage, string Vmobno, string Date, string Time)
        {
            DataTable dt = GetSMSSettings();
            if (dt.Rows.Count == 0)
                return null;
            string Username = dt.Rows[0]["UserId"].ToString();
            string Password = dt.Rows[0]["Pswd"].ToString();
            string SenderId = dt.Rows[0]["SenderId"].ToString();

            string outputBuffer = "where=46038";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://bulksms.dnsitexperts.com/sendsms.jsp?user=" + Username + "&password=" + Password + "&mobiles=" + Vmobno + "&senderid=" + SenderId + "&sms=" + Vmessage + "");
            req.Method = "POST";
            req.ContentLength = outputBuffer.Length;
            req.ContentType = "application/x-www-form-urlencoded";
            StreamWriter swOut = new StreamWriter(req.GetRequestStream());
            swOut.Write(outputBuffer);
            swOut.Close();
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string buffer = sr.ReadToEnd();
            return buffer;
        }

        private DataTable GetSMSSettings()
        {

            // Services
            DataTable dt = new DataTable();
            return dt;
            //SMSSettingsTableAdapter sMSSettingsTableAdapter = new SMSSettingsTableAdapter();
            //DataTable dt = cls.GetDataTable("select * from SMSAPISetting");
            //sMSSettingsTableAdapter.GetSMSSettings();
            //return dt;
        }

        public string SendClientSMS(string Vmessage, string Vmobno)
        {
            string Username = "dnsitexp";
            string Password = "dns@123";
            string SenderId = "DNSITE";

            string outputBuffer = "where=46038";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://banksms.dnsitexperts.com/sendsms.jsp?user=" + Username + "&password=" + Password + "&mobiles=" + Vmobno + "&senderid=" + SenderId + "&sms=" + Vmessage + "");
            req.Method = "POST";
            req.ContentLength = outputBuffer.Length;
            req.ContentType = "application/x-www-form-urlencoded";
            StreamWriter swOut = new StreamWriter(req.GetRequestStream());
            swOut.Write(outputBuffer);
            swOut.Close();
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string buffer = sr.ReadToEnd();
            return buffer;
        }

        public string SendSingleSMS(string Username, string Password, string SenderId, string Vmessage, string Vmobno)
        {
            //string outputBuffer = "where=46038";
            string buffer = "";
            buffer = GetSMSBalanceForBulkSms("http://bulksms.dnsitexperts.com/sendsms.jsp?user=" + Username + "&password=" + Password + "&mobiles=" + Vmobno + "&senderid=" + SenderId + "&sms=" + Vmessage + "");
            return buffer;

            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://bulksms.dnsitexperts.com/sendsms.jsp?user=" + Username + "&password=" + Password + "&mobiles=" + Vmobno + "&senderid=" + SenderId + "&sms=" + Vmessage + "");
            //req.Method = "POST";
            //req.ContentLength = outputBuffer.Length;
            //req.ContentType = "application/x-www-form-urlencoded";
            //StreamWriter swOut = new StreamWriter(req.GetRequestStream());
            //swOut.Write(outputBuffer);
            //swOut.Close();
            //HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            //StreamReader sr = new StreamReader(resp.GetResponseStream());
            //string buffer = sr.ReadToEnd();
            //return buffer;
        }
    }
}