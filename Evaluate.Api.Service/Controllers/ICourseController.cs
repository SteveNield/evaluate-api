using System.Threading.Tasks;
using System.Web.Http;

namespace Evaluate.Api.Service.Controllers
{
    public interface ICourseController
    {
        Task<IHttpActionResult> Get();
    }
}