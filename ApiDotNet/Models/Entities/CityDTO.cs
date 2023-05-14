namespace ApiDotNet.Models.Entities
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }


        // readonly property-just has getter not setter 
        // so just can retrieve it's value and can't set 
        // a value for that
        public int PointsOfIntersetCount
        {
            get
            {
                return PointsOfInterests.Count;
            }
        }


        //navigation properties
        // city (1) ---------- PointsofInterest (1...*)
        public ICollection<PointsOfInterestDTO> PointsOfInterests
        { get; set; } = new List<PointsOfInterestDTO>();
    }
}
