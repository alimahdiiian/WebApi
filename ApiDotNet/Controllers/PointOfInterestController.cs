using ApiDotNet.Models.DTOs;
using ApiDotNet.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ApiDotNet.Controllers
{
    //api/cities/3/pointofinterest
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<PointsOfInterestDTO>>
            GetPointsOfInterest(int cityId)//cityId is the same as cityId in route
        {
            var city = CitiesDataStore.citiesDataStoreInstance
                .CitiesList.FirstOrDefault(c => c.Id == cityId);

            var pointsOfInterest = city.PointsOfInterests.ToList();
            if (pointsOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointsOfInterest);
        }


        //[HttpGet("pointOfInterestId")] in this case 
        //pointOfInterestId is a fix name and url is :
        //https://localhost:7049/api/cities/1/pointsofinterest/pointOfInterestId?pointOfInterestId=1

        [HttpGet("{pointOfInterestId}", Name ="GetPoinOfInterest")]
        public ActionResult<PointsOfInterestDTO>
      GetPointsOfInterest(int cityId, int pointOfInterestId)
        {
            var city = CitiesDataStore.citiesDataStoreInstance
                .CitiesList.FirstOrDefault(c => c.Id == cityId);

            if (city==null)
            {
                return NotFound();
            }
            var pointOfInterest = city.PointsOfInterests
                .FirstOrDefault(p => p.pointOfInterestId == pointOfInterestId);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);

        }


        [HttpPost]
        public ActionResult<PointsOfInterestDTO> CreatePointOfInterest
            (int cityId, PointOfInterestForCreationDTO pointOfInterest)
        {

            // attribute that has assigned to property of 
            // pointofinterestcreationDTO should be considerd
            // otherwide Modelstate is not valid.
            if (! ModelState.IsValid)
            {
                return BadRequest();
            }
            var city = CitiesDataStore.citiesDataStoreInstance
                .CitiesList.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = CitiesDataStore
                .citiesDataStoreInstance.CitiesList
                .SelectMany(c => c.PointsOfInterests)
                .Max(p => p.pointOfInterestId);

            var createPointOfInterest = new PointsOfInterestDTO
            {
                pointOfInterestId = ++maxPointOfInterestId,
                Description = pointOfInterest.Description,
                Name = pointOfInterest.Name,
                cityId = cityId,

            };

            city.PointsOfInterests.Add(createPointOfInterest);

            return CreatedAtAction("GetPointOfInterest",
       new
       {
            cityId,
           createPointOfInterest.pointOfInterestId

       },
       createPointOfInterest
   );
        }




    }
}
