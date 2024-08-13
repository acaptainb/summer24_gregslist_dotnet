



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

  public Car UpdateCar(int carId, string userId, Car carData)
  {
    Car carToUpdate = GetCarById(carId);

    if (carToUpdate.CreatorId != userId)
    {
      throw new Exception("YOU CANNOT UPDATE A CAR YOU DID NOT CREATE, THAT IS FORBIDDEN, PLEASE IGNORE THE 400 ERROR CODE, IT SHOULD BE 403");
    }

    carToUpdate.Description = carData.Description ?? carToUpdate.Description;
    carToUpdate.ImgUrl = carData.ImgUrl ?? carToUpdate.ImgUrl;
    carToUpdate.Price = carData.Price ?? carToUpdate.Price;
    carToUpdate.LeaksOil = carData.LeaksOil ?? carToUpdate.LeaksOil;

    _carsRepository.UpdateCar(carToUpdate);

    return carToUpdate;
  }
}