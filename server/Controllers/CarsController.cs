namespace gregslist_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")] // will take then name of your controller, shave off the controller part, and put that in the string
public class CarsController : ControllerBase
{
  private readonly CarsService _carsService;

  public CarsController(CarsService carsService)
  {
    _carsService = carsService;
  }

  [HttpGet]
  public ActionResult<List<Car>> GetAllCars()
  {
    try
    {
      List<Car> cars = _carsService.GetAllCars();
      return Ok(cars);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{carId}")]
  public ActionResult<Car> GetCarById(string carId)
  {
    try
    {
      Car car = _carsService.GetCarById(carId);
      return Ok(car);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}