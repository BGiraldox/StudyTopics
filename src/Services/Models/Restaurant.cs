using Services.Mocks;

namespace Services.Models
{
    public class Restaurant : IEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Code { get; set; }
    }
}