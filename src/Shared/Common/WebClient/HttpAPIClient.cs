using Newtonsoft.Json;
using RestSharp;
using Serilog;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Omniture.Shared.WebClient
{
    public class HttpApiClient
    {
        public static Task<IRestResponse> Post(string url, string token, object parameter)
        {
            var client = new RestClient();
            if (!string.IsNullOrEmpty(token))
                client.AddDefaultHeader("Authorization", $"Bearer {token}");
            var request = new RestRequest(url);
            request.AddJsonBody(parameter);
            var response = client.ExecutePostAsync(request);
            return response;
        }
        public static T Get<T>(string url, string token, object parameter = null) where T : new()
        {
            Log.Information("HttpAPIClient.Get url:{url},{parameter}", url, parameter);
            var client = new RestClient();
            if (!string.IsNullOrEmpty(token))
                client.AddDefaultHeader("Authorization", $"Bearer {token}");
            var request = new RestRequest(url, Method.GET);
            if (parameter != null)
                request.AddJsonBody(parameter);
            var response = client.Get<T>(request);
            Log.Information("HttpAPIClient.Get url:{url},{parameter}", url, response);
            return response.Data;
        }
        public static byte[] GetFile(string url, string token, object parameter = null)
        {
            Log.Information("HttpAPIClient.Get url:{url},{parameter}", url, parameter);
            var client = new RestClient();
            if (!string.IsNullOrEmpty(token))
                client.AddDefaultHeader("Authorization", $"Bearer {token}");
            var request = new RestRequest(url, Method.GET);
            if (parameter != null)
                request.AddJsonBody(parameter);
            return client.DownloadData(request);
            //var response = client.Get(request);
        }
        public static byte[] GetFilePost(string url,  object parameter = null)
        {
            Log.Information("HttpAPIClient.Get url:{url},{parameter}", url, parameter);
            var client = new RestClient();
            //if (!string.IsNullOrEmpty(token))
            //    client.AddDefaultHeader("Authorization", $"Bearer {token}");
            var request = new RestRequest(url, Method.POST);
            if (parameter != null)
                request.AddJsonBody(parameter);
            return client.DownloadData(request);
            //var response = client.Get(request);
        }
        public static IRestResponse Get(string url, string token, object parameter = null)
        {
            Log.Information("HttpAPIClient.Get url:{url},{parameter}", url, parameter);
            var client = new RestClient();
            if (!string.IsNullOrEmpty(token))
                client.AddDefaultHeader("Authorization", $"Bearer {token}");
            var request = new RestRequest(url, Method.GET);
            if (parameter != null)
                request.AddJsonBody(parameter);
            var response = client.Get(request);
            Log.Information("HttpAPIClient.Get url:{url},{response}", url, response);
            return response;
        }
        public static string XmlPost(string url, string token, Byte[] data)
        {
            WebRequest myWebRequest = WebRequest.Create(url);

            myWebRequest.ContentType = "application/x-www-form-urlencoded";

            myWebRequest.Method = "POST";

            myWebRequest.ContentLength = data.Length;
            Stream dataStream = myWebRequest.GetRequestStream();
            dataStream.Write(data, 0, data.Length);
            dataStream.Close();
            WebResponse myWebResponse = myWebRequest.GetResponse();

            var streamResponse = myWebResponse.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            Char[] readBuff = new Char[256];
            int count = streamRead.Read(readBuff, 0, 256);

            String outputstring = String.Empty;

            while (count > 0)
            {
                String outputData = new String(readBuff, 0, count);
                Console.Write(outputData);
                outputstring += outputData;
                count = streamRead.Read(readBuff, 0, 256);
            }

            return outputstring;

        }
    }

}