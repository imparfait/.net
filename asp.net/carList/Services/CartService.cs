﻿using BusinessLogic.Interfaces;
using carShop;
using carShop.Entities;
using carShop.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace carList.Services
{
    public class CartService: ICartService
	{
		private readonly ICarService service;
		private readonly HttpContext? httpContext;
        public CartService(ICarService service, IHttpContextAccessor httpContextAccessor, CarContext context)
        {
            this.service = service;
            this.httpContext = httpContextAccessor.HttpContext;
        }
        public void Add(int carId)
		{
			var carIds = httpContext.Session.GetObject<List<int>>("cart");
			if (carIds == null) { carIds = new List<int>(); }
			carIds.Add(carId);

            httpContext.Session.SetObject("cart", carIds);
		}

		public List<Car> GetCars()
		{
			var carIds = httpContext.Session.GetObject<List<int>>("cart");
			List<Car> cars = new List<Car>();
			if (carIds != null)
			{
				cars = service.Get(carIds.ToArray());
			}
			return cars;
		}

		public bool IsInCart(int carId)
		{
			var carIds = httpContext.Session.GetObject<List<int>>("cart");
			if (carIds == null) { return false; }
			return carIds.Contains(carId);
		}

		public void Remove(int carId)
		{
			var carIds = httpContext.Session.GetObject<List<int>>("cart");
			if (carIds == null) { carIds = new List<int>(); }
			carIds.Remove(carId);
			httpContext.Session.SetObject("cart", carIds);
        }
        public void ClearCart()
        {
            var carIds = httpContext.Session.GetObject<List<int>>("cart");
            if (carIds == null) { carIds = new List<int>(); }
            carIds.Clear();
            httpContext.Session.SetObject("cart", carIds);
        }
    }
}
