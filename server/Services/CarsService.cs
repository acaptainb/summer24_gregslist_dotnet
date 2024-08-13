



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

  public Car GetCarById(int carId)
  {
    Car car = _carsRepository.GetCarById(carId);

    if (car == null)
    {
      throw new Exception($"No car found with the id of {carId}");
    }

    return car;
  }

  public Car CreateCar(Car carData)
  {
    Car car = _carsRepository.CreateCar(carData);
    return car;
  }

  public string DestroyCar(int carId, string userId)
  {
    Car car = GetCarById(carId);

    if (car.CreatorId != userId)
    {
      throw new Exception("YOU DID NOT CREATE THIS CAR GOBLIN GOBLIN 👺👺👺👺");
    }

    _carsRepository.DestroyCar(carId);

    return $"Your {car.Make} {car.Model} has been deleted!";
  }
}