namespace ApiDotNet.Models.Entities
{
    //complex type class(PointOfInterestDTO)
    public class PointsOfInterestDTO
    {
        public int pointOfInterestId { get; set; }
        public string Name { get; set; }
        = string.Empty;
        public string? Description { get; set; }

        //navigation propeties 
        public int cityId { get; set; }
        public City City { get; set; }


    }
}
