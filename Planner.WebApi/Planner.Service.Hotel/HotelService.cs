using AutoMapper;
using Planner.Data.Domain;

using Planner.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Planner.Service.Hotel
{
    public class HotelService : IHotelService
    {
        // private static List<HotelDTO> Hotels = new List<HotelDTO>();

        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public HotelService(
            IMapper mapper,
            DataContext context
        )
        {
            _mapper = mapper;
            _context = context;
        }
        public HotelDTO GetHotel()
        {
            var hotel = _context.Hotel.FirstOrDefault();
            if (hotel == null)
            {
                var hotelDTO = new HotelDTO()
                {
                     Id = 1,
                     Price =211,
                     Name ="test hotel",
                     Description ="test hotel description",
                     Address ="test adress",
                     NrOfRooms = 3,
                     OwnerId =1
                 };
                return hotelDTO;
            }
            var mappedHotel = _mapper.Map<HotelDTO>(hotel);

            return mappedHotel;
        }
      /*  public HotelDTO CreateHotel(HotelDTO hotel)
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
        }*/ 
    }
}
