using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PasjaTutorial.Models;
using PasjaTutorial.Services;

namespace PasjaTutorial.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantServices _restaurantService;
        public RestaurantController(IRestaurantServices restaurantServices)
        {
            _restaurantService = restaurantServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurants = _restaurantService.GetAll();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> GetOne([FromRoute] int id)
        {
            var restaurant = _restaurantService.GetById(id);
            return Ok(restaurant);
        }

        [HttpPost]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {

            var id = _restaurantService.Create(dto);
            return Created($"/api/restaurant/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        { 
            _restaurantService.Delete(id);
            return Ok(); 
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute]int id,[FromBody] UpdateRestaurantDto dto)
        {
            _restaurantService.Update(id,dto);
            return Ok();
        }
    }
}
