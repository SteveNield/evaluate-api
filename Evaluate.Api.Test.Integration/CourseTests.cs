using System.Configuration;
using System.Net;
using NUnit.Framework;

namespace Evaluate.Api.Test.Integration
{
    [TestFixture]
    public class CourseTests
    {
        [Test]
        public void Can_Return_List_Of_Courses()

        {
            var client = new WebClient { BaseAddress = ConfigurationManager.AppSettings["Evaluate.Service.Endpoint"] };
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.Headers.Add(HttpRequestHeader.Authorization, "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJXaW50ZXIuQXV0aCIsImF1ZCI6Imh0dHA6Ly93d3cudGVzdC5jb20iLCJuYmYiOjE0NDU0OTQ5MzIsImV4cCI6MTQ0NTQ5NTUzMiwidW5pcXVlX25hbWUiOiJURVNUIiwicm9sZSI6ImFkbWluIn0.ZJHt8zIVQapjP0rxQ39vcR0qo9-H_Gr9E7_Xm-UC_7k");

            var response = client.DownloadData("course");

            Assert.IsNotNull(response);
        }
    }
}
