using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecaptchaGoogleCSharpExample
{
    public partial class ReCaptchaEx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btnvalida_Click(object sender, EventArgs e)
        {
            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "true" ? true : false);

            if (IsCaptchaValid)
            {
                //Valid Request
                LblEsito.Text = "validazione ok";
            }
            else
            {
                LblEsito.Text = "errore validazione";
            }
            //if (!checkRecaptcha(request.ReCaptcha, "6LfD8GAUAAAAAJFXoMzqt3FHHRwpsypGBJKtLxwi"))
            //{

            //}

        }

        private bool checkRecaptcha(string recaptchaResponse, string recaptchaKey)
        {
            bool res = false;

            if (!string.IsNullOrEmpty(recaptchaResponse))
            {
                string postData = $"secret={recaptchaKey}&response={recaptchaResponse}";

                var webRequest = WebRequest.Create($"https://www.google.com/recaptcha/api/siteverify?{postData}");
                webRequest.Method = "GET";
                var webResponse = webRequest.GetResponse();
                var stream = webResponse.GetResponseStream();
                var reader = new StreamReader(stream);

                string responseFromServer = reader.ReadToEnd();
                var jo = JObject.Parse(responseFromServer);
                try
                {
                    res = Convert.ToBoolean(jo["success"]);
                }
                catch { }

                reader.Close();
                stream.Close();
                webResponse.Close();
            }

            return res;
        }
    }
}