namespace Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public Manufacturer Manufacturer{get;set;}
        public int Horsepower { get; set; }
        
    }
}