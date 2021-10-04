using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Planner.DTOs;
using Planner.Service.Auth;
using Planner.Service.Hotel;

namespace Planner.WebApi.Controllers
{
    public class HotelController
    {
        [Route("[controller]")]
        [ApiController]
        public class UserController : ControllerBase
        {
            //public IAuthService _authService;

            //public UserController(IAuthService authService)
            //{
            //    _authService = authService;
            //}
            private HotelService hotelService = new HotelService();

            [HttpPost]
            [Route("create")]
            public ActionResult<HotelDTO> CreateHotel([FromBody] HotelDTO hotel)
            {
                return Created("id/" + hotel.Id, this.hotelService.CreateHotel(hotel));
            }
        }
    }
}
