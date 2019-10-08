using System;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace TfLUnifiedAPI.Test
{
    [TestFixture]
    public class SingleTfLLineServiceTests
    {
        SingleTfLLines singleTfLLine = new SingleTfLLines();

        public SingleTfLLineServiceTests()
        {
            singleTfLLine.GetSingleTfLLine("central");
        }

        [Test]
        public void Status200()
        {
            Assert.AreEqual(200, singleTfLLine.ResponseCode);
        }

        [Test]
        public void ReturnCorrectTfLLine()
        {
            Assert.AreEqual("central", singleTfLLine.TfLLineSingleResponseContent["id"].ToString());
        }

        [Test]
        public void ReturnCorrectTfLLineMode()
        {
            Assert.AreEqual("tube", singleTfLLine.TfLLineSingleResponseContent["modeName"].ToString());
        }

        [Test]
        public void ReturnTfLLineStatus()
        {
            Assert.AreEqual("Good Service", singleTfLLine.TfLLineSingleResponseContent["lineStatuses"][0]["statusSeverityDescription"].ToString());
        }

        [Test]
        public void TestServerHeader()
        {
            Assert.AreEqual("Server", singleTfLLine.restResponse.Headers[24].Name.ToString());
            Assert.AreEqual("cloudflare", singleTfLLine.restResponse.Headers[24].Value.ToString());
            
        }
    }
}
