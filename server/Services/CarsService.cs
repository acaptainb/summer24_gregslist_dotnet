


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

  public Car GetCarById(string carId)
  {
    Car car = _carsRepository.GetCarById(carId);
    return car;
  }

  public Car CreateCar(Car carData)
  {
    Car car = _carsRepository.CreateCar(carData);
    return car;
  }
}