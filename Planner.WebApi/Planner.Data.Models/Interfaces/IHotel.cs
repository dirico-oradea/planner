namespace Planner.Data.Models.Interfaces
{
    interface IHotel
    {
        int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int NrOfRooms { get; set; }
        public int OwnerId { get; set; }
    }
}
