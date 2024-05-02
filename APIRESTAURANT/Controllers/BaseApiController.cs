using Microsoft.AspNetCore.Mvc;

namespace APIRESTAURANT.Controllers.v1
{
        [ApiController]
        [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase

    {




    }
}
