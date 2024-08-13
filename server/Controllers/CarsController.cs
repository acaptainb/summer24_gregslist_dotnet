namespace gregslist_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")] // will take then name of your controller, shave off the controller part, and put that in the string
public class CarsController : ControllerBase
{

  [HttpGet]
  public ActionResult<List<Car>> GetAllCars()
  {
    try
    {
      return Ok("SUP");
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}