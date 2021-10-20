using AutoMapper;
using Planner.Data.Domain;
using Planner.DTOs;
using System.Collections.Generic;
using System.Linq;
using Planner.Data.Models;

namespace Planner.Service.HotelAuth
{
    public class HotelService : IHotelService
    {
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
            var hotel = _context.Hotels.FirstOrDefault();
            if (hotel == null)
            {
                var hotelDTO = new HotelDTO()
                {
                    //Id = 1,
                    Price = 211,
                    Name = "test hotel",
                    Description = "test hotel description",
                    Address = "test adress",
                    NrOfRooms = 3,
                    OwnerId = 1
                };
                return hotelDTO;
            }
            var mappedHotel = _mapper.Map<HotelDTO>(hotel);

            return mappedHotel;
        }
        public string CreateHotel(HotelDTO hotelDTO)
        {
            _context.Hotels.Add(_mapper.Map<Hotel>(hotelDTO));
            return hotelDTO.Name;
        }
        public HotelDTO UpdateHotelById(int hotelId, HotelDTO changedHotel)
        {
            Hotel hotelToUpdate = _context.Hotels.First(s => s.Id == hotelId); ;

            //hotelToUpdate.Id = changedHotel.Id;
            hotelToUpdate.Name = changedHotel.Name;
            hotelToUpdate.Price = changedHotel.Price;
            hotelToUpdate.Description = changedHotel.Description;
            hotelToUpdate.Address = changedHotel.Address;
            hotelToUpdate.NrOfRooms = changedHotel.NrOfRooms;

            return _mapper.Map<HotelDTO>(hotelToUpdate);
        }
        public List<HotelDTO> GetHotelsByOwnerId(int ownerId)
        {
            List<Hotel> myHotels = _context.Hotels.Where(s => s.OwnerId == ownerId).ToList();
            return _mapper.Map<List<HotelDTO>>(myHotels);
        }
        public List<HotelDTO> GetAllHotels()
        {
            List<Hotel> allHotels = _context.Hotels.ToList();
            return _mapper.Map<List<HotelDTO>>(allHotels);
        }
    }
}
