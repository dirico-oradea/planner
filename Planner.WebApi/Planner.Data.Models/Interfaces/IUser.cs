namespace Planner.Data.Models.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
