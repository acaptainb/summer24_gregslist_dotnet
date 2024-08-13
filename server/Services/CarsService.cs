
namespace gregslist_dotnet.Services;

public class CarsService
{
  private readonly CarsRepository _carsRepository;

  public CarsService(CarsRepository carsRepository)
  {
    _carsRepository = carsRepository;
  }

  public List<Car> GetAllCars()
  {
    List<Car> cars = _carsRepository.GetAllCars();
    return cars;
  }
}