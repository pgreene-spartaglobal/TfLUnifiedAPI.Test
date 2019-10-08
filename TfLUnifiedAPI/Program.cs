using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Net;

namespace TfLUnifiedAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleTfLLines singleTfLLines = new SingleTfLLines();
            string result = singleTfLLines.GetSingleTfLLine("central").ToString();
            Console.WriteLine(result);
        }
    }
    public static class AppConfigReader
    {
        public static string BaseUri = ConfigurationManager.AppSettings["base_uri"];
    }
    public class SingleTfLLines
    {
        public RestClient Client { get; set; }
        public JObject TfLLineSingleResponseContent { get; set; }
        public string LineSelected { get; set; }
        public int ResponseCode { get; set; }
        public SingleTfLLines() => Client = new RestClient
        {
            BaseUrl = new Uri("https://api.tfl.gov.uk")
        };
        public JObject GetSingleTfLLine(string line)
        {
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            LineSelected = line;
            request.Resource = $"Line/{line.ToLower().Replace(" ", "")}";
            IRestResponse response = Client.Execute(request);
            HttpStatusCode statusCode = response.StatusCode;
            ResponseCode = (int)statusCode;
            response.Content = response.Content.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });
            TfLLineSingleResponseContent = JObject.Parse(response.Content);
            return TfLLineSingleResponseContent;
        }
    }
}
