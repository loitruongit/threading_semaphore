using Microsoft.AspNetCore.Mvc;

namespace threading_semaphore.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
