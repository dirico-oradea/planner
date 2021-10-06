using Planner.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.Data.Models
{
    public class User : IUser
    {
        [Column(Order = 0)]
        public int Id { get; set; }

        [Column(Order = 1)]
        public string UserName { get; set; }

        [Column(Order = 2)]
        public string Password { get; set; }

        [Column(Order = 3)]
        public string FirstName { get; set; }

        [Column(Order = 4)]
        public string LastName { get; set; }

        [Column(Order = 5)]
        public string Avatar { get; set; }

        [Column(Order = 6)]
        public string Token { get; set; }
    }
}
