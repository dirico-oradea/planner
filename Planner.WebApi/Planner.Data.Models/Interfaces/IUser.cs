﻿namespace Planner.Data.Models.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string Token { get; set; }
    }
}
