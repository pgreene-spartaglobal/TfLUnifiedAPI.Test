using System;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

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
    }
}
