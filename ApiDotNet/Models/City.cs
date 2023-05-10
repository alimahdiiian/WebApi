namespace ApiDotNet.Models
{
    public class City
    {
        public int cityId { get; set; }
        public DateOnly Date { get; set; }

        public string Country { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Name { get; set; }
    }
}
