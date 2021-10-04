namespace Planner.DTOs
{
    public class HotelDTO 
    {
       public int Id { get; set; }
       public int Price { get; set; }
       public string Name { get; set; }
       public string  Description { get; set; }
       public string Address { get; set; }       
       public string NrOfRooms  {get; set; }
       public int OwnerId { get; set; }
    
}
}
