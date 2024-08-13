

namespace gregslist_dotnet.Repositories;

public class CarsRepository
{
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Car> GetAllCars()
  {
    string sql = @"
    SELECT 
    cars.*,
    accounts.*
    FROM cars 
    JOIN accounts ON accounts.id = cars.creatorId;";

    // first type passed to query is the first data type on the row
    // second type passed to query is the second data type on the row
    // third type passed to query is the return type for the mapping function
    List<Car> cars = _db.Query<Car, Profile, Car>(sql, (car, account) =>
    {
      car.Creator = account;
      return car;
    }).ToList();

    return cars;
  }

  public Car GetCarById(string carId)
  {
    string sql = "SELECT * FROM cars WHERE id = @carId;";

    Car car = _db.Query<Car>(sql, new { carId }).FirstOrDefault();

    return car;
  }
}