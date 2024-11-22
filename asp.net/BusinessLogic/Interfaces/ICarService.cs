using carShop.Entities;

namespace BusinessLogic.Interfaces
{
    public interface ICarService
	{
		List<Car> GetAll();
		List<Car> Get(int[] ids);
		Car? GetById(int id);
		void Create(Car car);
		void Edit(Car car);
		void Delete(int id);
        //Task<IEnumerable<Car>> GetCars();

    }
}
