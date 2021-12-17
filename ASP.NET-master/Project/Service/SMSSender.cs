using System;
using System.Net;
using System.Text;
using System.IO;

namespace Project.Service
{
    public class SMSSender
    {
        public string ApiToken { get; set; }

        public string DeviceId { get; set; }
        public string Numbers { get; set; }
        public string Message { get; set; }



        private string result;
        private WebRequest request = null;
        private HttpWebResponse response = null;

        public SMSSender()
        {
            
            request = null;
            response = null;
        }
        public bool Send()
        {

            string url = "http://sms.tnrsoft.com/services/send.php?key=" + ApiToken + "&number=" + Numbers + "&message=" + Uri.EscapeUriString(Message) + "&devices=" + DeviceId + "&type=sms&prioritize=1";


           // System.Diagnostics.Debug.WriteLine(url);

            try
            {

                


                request = WebRequest.Create(url);
                // Send the 'HttpWebRequest' and wait for response.
                response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                Encoding ec = Encoding.GetEncoding("utf-8");
                using (StreamReader reader = new
                StreamReader(stream, ec))
                {
                    result = reader.ReadToEnd();
                    ///Console.WriteLine(result);
                    reader.Close();
                }
                stream.Close();
                return true;
            }
            catch
            {
                
                return false;
            }
            finally
            {
                if (response != null)
                    response.Close();
                

            }

        }
    }
}