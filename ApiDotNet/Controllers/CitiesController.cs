using ApiDotNet.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.NetworkInformation;

namespace ApiDotNet.Controllers
{
    //public class CitiesController : Controller
    //don't need View => so insted of controller use controllerbase



    [ApiController]
    //[Route("api/[controller]")] a fix name is better
    [Route("api/Cities")]
    public class CitiesController : ControllerBase
    {
        private static readonly string[] Cities =
            new[] { "Tehran", "Berlin", "Paris", "London" };
        private static readonly int[] cityIds =
            new[] { 1, 2, 3, 4 };
        List<City> citiesList = new List<City>();
        

        private readonly ILogger<CitiesController> _logger;
        public CitiesController(ILogger<CitiesController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetCities")]
        public ActionResult<IEnumerable<CityDTO>> GetCities()
        {
            var cityList = CitiesDataStore.citiesDataStoreInstance.CitiesList;
            if (cityList==null)
            {
                return NoContent();
            }

            return Ok(cityList);
        }


        [HttpGet("{id}")]
        public ActionResult<CityDTO> GetCity(int id)
        {
            var city = CitiesDataStore.citiesDataStoreInstance.CitiesList
                .FirstOrDefault(c => c.Id == id);

            if (city !=null)
            {
                return Ok(city);
            }
            if (city!=null && city.Name=="")
            {
                return NoContent();
            }

            return NotFound();

        }

        //[HttpGet]
        //public IEnumerable<City> GetCities()
        //{
        //    return Enumerable.Range(1, 6).Select(city => new City
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(city)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Name = Cities[Random.Shared.Next(Cities.Length)],
        //        cityId = cityIds[Random.Shared.Next(cityIds.Length)]
        //    })
        //        .ToArray();
        //}

        [HttpPost]
        public IEnumerable<City> PostCity()
        {
            var city = new City()
            {
                cityId = 5,
                Country = "Canada",
                Name = "Ottawa",
                Date = DateOnly.MinValue,
                TemperatureC = 10,
            };

            citiesList.Add(city);
           
            return citiesList;
        }



    }
}
