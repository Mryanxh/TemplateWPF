/* ===============================================
* 功能描述：HttpWebUtil  
* 创 建 人：燕晓贺
* 创建日期：2021/2/2 14:22:54
* CLR版本：4.0.30319.42000
* 机器名称：YANXH-PC
* 用户所在域：YANXH-PC
* 注册组织名：
* 命名空间名称：TemplateWPF.Utils
* 当前登录用户名：mryan
* ================================================*/

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TemplateWPF.Utils
{
    public class HttpWebUtil
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// HttpGet
        /// </summary>
        /// <param name="url"></param>
        /// <param name="HttpContentType"></param>
        /// <returns></returns>
        public static string GetHttpResponse(string url, string HttpContentType = "text/html;charset=UTF-8")
        {
            string retString;
            try
            {
                Logger.InfoFormat("HttpGet:Url:{0},ContentType:{1}", url, HttpContentType);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = HttpContentType;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
            }
            catch (Exception ex)
            {
                retString = ex.Message;
                Logger.ErrorFormat("HttpGet:Exception:{0}", ex.Message);
            }
            return retString;
        }
        /// <summary>
        /// PostData
        /// </summary>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static string PostHttpResponse(string url, string content,string contentType= "application/x-www-form-urlencoded")
        {
            string result;
            try
            {
                result = string.Empty;
                byte[] contentBytes = Encoding.ASCII.GetBytes(content);
                HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = contentType;
                httpWebRequest.ContentLength = content.Length;

                using (Stream reqStream = httpWebRequest.GetRequestStream())
                {
                    reqStream.Write(contentBytes, 0, content.Length);
                }
                if (httpWebRequest.GetResponse() is HttpWebResponse httpWebResponse)
                {
                    using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        result = sr.ReadToEnd();
                    }
                    httpWebResponse.Close();
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public static string PostHttpResponse(string url, string postData, string userName, string password)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "text/html; charset=UTF-8";
            request.Method = "POST";

            string usernamePassword = userName + ":" + password;
            CredentialCache credentialCache =
                new CredentialCache { { new Uri(url), "Basic", new NetworkCredential(userName, password) } };
            request.Credentials = credentialCache;
            request.Headers.Add("Authorization",
                "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(usernamePassword)));

            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(bytes, 0, bytes.Length);
            writer.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException(), Encoding.ASCII);
            string result = reader.ReadToEnd();
            response.Close();
            return result;
        }

        public static void SetHeaderValue(WebHeaderCollection header, string name, string value)
        {
            var property =
                typeof(WebHeaderCollection).GetProperty("InnerCollection",
                    BindingFlags.Instance | BindingFlags.NonPublic);
            if (property != null)
            {
                if (property.GetValue(header, null) is NameValueCollection collection) collection[name] = value;
            }
        }
    }
}
