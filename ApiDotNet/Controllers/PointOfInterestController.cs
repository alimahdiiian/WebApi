using ApiDotNet.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{pointOfInterestId}")]
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
                .FirstOrDefault(p => p.Id == pointOfInterestId);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);

        }



    }
}
