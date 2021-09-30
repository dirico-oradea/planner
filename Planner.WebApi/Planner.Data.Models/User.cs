using Planner.Data.Models.Interfaces;

namespace Planner.Data.Models
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
