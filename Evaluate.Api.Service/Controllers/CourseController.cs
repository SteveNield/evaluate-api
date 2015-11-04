using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Evaluate.Api.Model;

namespace Evaluate.Api.Service.Controllers
{
    public class CourseController : ApiController, ICourseController
    {
        // GET: Course
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> Get()
        {
            return await Task.Run(() => Ok(new List<Course> { new Course("Test Course") }));
        }
    }
}