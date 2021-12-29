using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PasjaTutorial.Entities;
using PasjaTutorial.Models;
using System.Collections.Generic;
using System.Linq;
using PasjaTutorial.Exceptions;

namespace PasjaTutorial.Services
{
    public interface IRestaurantServices
    {
        RestaurantDto GetById(int id);
        IEnumerable<RestaurantDto> GetAll();
        int Create(CreateRestaurantDto dto);
        void Delete(int id);
        void Update(int id, UpdateRestaurantDto dto);
    }

    public class RestaurantServices : IRestaurantServices
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;
        public RestaurantServices(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public RestaurantDto GetById(int id)
        {
            var restaurant = _dbContext
              .Restaurants
              .Include(r => r.Address)
              .Include(r => r.Dishes)
              .FirstOrDefault(x => x.Id == id);

            if (restaurant is null)
            {
                throw new NotFoundException("Restaurant not found");
            }
            var result = _mapper.Map<RestaurantDto>(restaurant);
            return result;
        }

        public IEnumerable<RestaurantDto> GetAll()
        {
            var restaurants = _dbContext
                .Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .ToList();
            var restaurantsDtos = _mapper.Map<List<RestaurantDto>>(restaurants);
            return restaurantsDtos;
        }

        public int Create(CreateRestaurantDto dto)
        {
            var restaurant = _mapper.Map<Restaurant>(dto);
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
            return restaurant.Id;
        }

        public void Delete(int id)
        {
            var restaurant = _dbContext
                .Restaurants
                .FirstOrDefault(x => x.Id == id);
            if (restaurant is null) throw new NotFoundException("Restaurant not found");

            _dbContext.Restaurants.Remove(restaurant);
            _dbContext.SaveChanges();
        }

        public void Update(int id, UpdateRestaurantDto dto)
        {
            var restaurant = _dbContext
                .Restaurants
                .FirstOrDefault(x => x.Id == id);

            if(restaurant is null) throw new NotFoundException("Restaurant not found");

            restaurant.Name = dto.Name;
            restaurant.Description = dto.Description;
            restaurant.HasDelivery = dto.HasDelivery;

            //_dbContext.Restaurants.Update(restaurant);
            _dbContext.SaveChanges();
        }
    }
}
