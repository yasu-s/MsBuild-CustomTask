namespace CustomTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Build.Framework;

    /// <summary>
    /// AccessUrlTask
    /// </summary>
    public class AccessUrlTask : AbstractTask
    {
        [Required]
        public string Url
        {
            get;
            set;
        }
     
        public override bool Execute()
        {
            bool result = false;
            HttpStatusCode code;

            try
            {
                WriteHeaderInfo("AccessUrlTask");

                if (!IsValidation()) return false;

                Console.WriteLine("ACCESS URL: {0}", Url);

                code = GetStatusCode(Url);

                Console.WriteLine("HTTP STATUS: {0}", code);

                result = (((int)HttpStatusCode.OK <= (int)code) && ((int)code < (int)HttpStatusCode.MultipleChoices));
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }

        private bool IsValidation()
        {
            if (string.IsNullOrWhiteSpace(Url))
            {
                Console.WriteLine("Url is null.");
                return false;
            }

            return true;
        }

        private HttpStatusCode GetStatusCode(string url)
        {
            HttpStatusCode code;
            HttpWebRequest req  = null;
            HttpWebResponse res = null;

            try
            {
                req  = WebRequest.Create(url) as HttpWebRequest;
                res  = req.GetResponse() as HttpWebResponse;
                code = res.StatusCode;
            }
            catch (WebException ex)
            {
                res = ex.Response as HttpWebResponse;

                if (res != null)
                    code = res.StatusCode;
                else
                    throw ex;
            }
            finally
            {
                if (res != null)
                    res.Close();
            }

            return code;
        }
    }
}
