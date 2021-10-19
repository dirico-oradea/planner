using Planner.DTOs;
using System.Collections.Generic;

namespace Planner.Service.HotelAuth
{
    public interface IHotelService
    {
        HotelDTO GetHotel();
        string CreateHotel(HotelDTO hotel);
        HotelDTO UpdateHotelById(int hotelId, HotelDTO changedHotel);
        List<HotelDTO> GetHotelsByOwnerId(int ownerId);
    }
}
