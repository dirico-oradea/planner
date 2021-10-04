using Planner.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Planner.Service.Hotel
{
    public class HotelService : IHotelService
    {
        private static List<HotelDTO> Hotels = new List<HotelDTO>();
        public HotelDTO CreateHotel(HotelDTO hotel)
        {
            Hotels.Add(hotel);
            return hotel;
        }
        public HotelDTO UpdateHotelById(int hotelId, HotelDTO changedHotel)
        {
            HotelDTO hotelToUpdate = Hotels.First(s => s.Id == hotelId); ;

            hotelToUpdate.Id = changedHotel.Id;
            hotelToUpdate.Name = changedHotel.Name;
            hotelToUpdate.Price = changedHotel.Price;
            hotelToUpdate.Description = changedHotel.Description;
            hotelToUpdate.Address = changedHotel.Address;
            hotelToUpdate.NrOfRooms = changedHotel.NrOfRooms;

            return hotelToUpdate;
        }

        public List<HotelDTO> GetHotelsByOwnerId(int ownerId)
        {
            return Hotels.Where(s => s.OwnerId == ownerId).ToList();
        }
    }
}
