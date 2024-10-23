using BusinessLogic.Interfaces;
using carShop;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
	public class CarService : ICarService
	{
		private readonly CarContext context;

		public CarService(CarContext context)
		{
			this.context = context;
		}
		public void Create(Car car)
		{
			context.Cars.Add(car);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var find = context.Cars.Find(id);
			if (find == null) return;

			context.Cars.Remove(find);
			context.SaveChanges();
		}

		public void Edit(Car car)
		{
			context.Cars.Update(car);
			context.SaveChanges();
		}

		public List<Car> Get(int[] ids)
		{
			return context.Cars.Where(p => ids.Contains(p.Id)).ToList();
		}

		public List<Car> GetAll()
		{
			return context.Cars.ToList();
		}

		public Car? GetById(int id)
		{
			if (id < 0) { return null; }

			var car = context.Cars.Find(id);

			if (car == null) { return null; }
			return car;
		}
	}
}
