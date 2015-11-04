using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Evaluate.Api.Model;
using Evaluate.Api.Service.Controllers;
using NUnit.Framework;

namespace Evaluate.Api.Test.Unit
{
    [TestFixture]
    public class CourseControllerTests
    {
        [Test]
        public async void Can_Return_List_Of_Courses()
        {
            var courseController = new CourseController();

            IHttpActionResult response = await courseController.Get();

            Assert.IsInstanceOf<OkNegotiatedContentResult<List<Course>>>(response);
            Assert.That(((OkNegotiatedContentResult<List<Course>>)response).Content.Any());
        }
    }
}
