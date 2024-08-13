
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
    string sql = "SELECT * FROM cars;";

    List<Car> cars = _db.Query<Car>(sql).ToList();

    return cars;
  }
}