using System;
using System.Net;
using System.IO;

namespace RoyalMail
{
    public sealed class Api: IDisposable    
    {
        private Common.Config _config;
        private string _errormessage;
        public StatusType Status { get; private set; }

        public enum StatusType {
           OK = 1,
           Error = 2
        }

        public Api()
        {
           _config = new Common.Config();
        }

        public void CreateWebRequest(RoyalMail.Call.Base call)
        {
            string context = call.GetSerializedObject();

            HttpWebRequest webRequest 
                       = (HttpWebRequest)WebRequest.Create(_config.UrlApp);

            CreateHeader(webRequest,call,context);

            using (var writer = new StreamWriter(webRequest.GetRequestStream()))
            {
                writer.Write(context.ToString());
            }

            try
            {
                HttpWebResponse httpWebReponse 
                        = (HttpWebResponse)webRequest.GetResponse();

                if (httpWebReponse.StatusCode == HttpStatusCode.OK)
                {
                    Status = StatusType.OK;
                }
                else
                {
                    Status = StatusType.Error;
                }
              
            }
            catch (Exception ex)
            {
                Status = StatusType.Error;
                _errormessage = ex.Message.ToString();
                throw ex;
            }
        }

        private void CreateHeader(HttpWebRequest webRequest, RoyalMail.Call.Base call, string Context) {
            webRequest.Accept = "application/xml";
            webRequest.Headers.Add(@"SOAPAction", call.SoapCall());
            webRequest.Headers.Add(@"X-IBM-Client-Secret", _config.ClientSecret);
            webRequest.Headers.Add(@"X-IBM-Client-Id", _config.ClientId);
            webRequest.ContentLength = Context.Length;
            webRequest.Method = "POST";
        }

        public void Dispose()
        {
            _config = null;
        }
    }
}
