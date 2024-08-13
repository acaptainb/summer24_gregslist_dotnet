



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

  public Car GetCarById(int carId)
  {
    string sql = @"
    SELECT 
    cars.*,
    accounts.* 
    FROM cars 
    JOIN accounts ON accounts.id = cars.creatorId 
    WHERE cars.id = @carId;";

    Car car = _db.Query<Car, Profile, Car>(sql, (car, account) =>
    {
      car.Creator = account;
      return car;
    }, new { carId }).FirstOrDefault();

    return car;
  }

  internal Car CreateCar(Car carData)
  {
    string sql = @"
    INSERT INTO 
    cars(make, model, year, engineType, price, color, imgUrl, description, leaksOil, creatorId)
    VALUES(@Make, @Model, @Year, @EngineType, @Price, @Color, @ImgUrl, @Description, @LeaksOil, @CreatorId);
    
    SELECT 
    cars.*,
    accounts.* 
    FROM cars
    JOIN accounts ON accounts.id = cars.creatorId 
    WHERE cars.id = LAST_INSERT_ID();";

    Car car = _db.Query<Car, Profile, Car>(sql, (car, account) =>
    {
      car.Creator = account;
      return car;
    }, carData).FirstOrDefault();
    return car;
  }

  public void DestroyCar(int carId)
  {
    string sql = "DELETE FROM cars WHERE id = @carId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { carId });

    if (rowsAffected == 0) throw new Exception("DELETE FAILED");
    if (rowsAffected > 1) throw new Exception("DELETE DID NOT FAIL, BUT THAT IS STILL A PROBLEM");
  }

  public void UpdateCar(Car carToUpdate)
  {
    string sql = @"
    UPDATE
    cars
    SET
    description = @Description,
    imgUrl = @ImgUrl,
    price = @Price,
    leaksOil = @LeaksOil
    WHERE id = @Id LIMIT 1;";

    int rowsAffected = _db.Execute(sql, carToUpdate);

    if (rowsAffected == 0) throw new Exception("UPDATE FAILED");
    if (rowsAffected > 1) throw new Exception("UPDATE DID NOT FAIL, BUT THAT IS STILL A PROBLEM");
  }
}