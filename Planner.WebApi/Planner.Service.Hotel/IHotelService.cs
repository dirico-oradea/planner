using Planner.DTOs;
using System.Collections.Generic;

namespace Planner.Service.Hotel
{
    interface IHotelService
    {
        HotelDTO CreateHotel(HotelDTO hotel);
        HotelDTO UpdateHotelById(int hotelId, HotelDTO changedHotel);
        List<HotelDTO> GetHotelsByOwnerId(int ownerId);
    }
}
