using Seido.Utilities.SeedGenerator;

namespace Models
{
    public class csWeather
    {
        public decimal Temp { get; set; }
        public string Visibility { get; set; }
        public override string ToString() => $"{Visibility} {Temp} degC";
    }
}