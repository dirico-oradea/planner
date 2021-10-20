using Microsoft.AspNetCore.Mvc;
using Planner.DTOs;
using Planner.Service.HotelAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.WebApi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        public IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        [HttpGet]
        [Route("")]
        public ActionResult<HotelDTO> GetHotel()
        {
            return _hotelService.GetHotel();
        }
        [HttpPost]
        [Route("create")]
        public ActionResult<string> CreateHotel([FromBody] HotelDTO hotelDTO)
        {
            return _hotelService.CreateHotel(hotelDTO);
        }

        [HttpPut]
        [Route("update/{studentId}")]
        public ActionResult<HotelDTO> UpdateHotelById([FromRoute] int hotelId, [FromBody] HotelDTO changedHotel)
        {
            try
            {
                return Ok(_hotelService.UpdateHotelById(hotelId, changedHotel));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("hotels/{OwnerId}")]
        public List<HotelDTO> GetHotelsByOwnerId([FromQuery] int ownerId)
        {
            return _hotelService.GetHotelsByOwnerId(ownerId);
        }

        [HttpGet]
        [Route("hotels")]
        public List<HotelDTO> GetAllHotels()
        {
            return _hotelService.GetAllHotels();
        }
        
    }
}
