using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkspaceManagement.BusinessLayer.IServices;
using WorkspaceManagement.DataAccessLayer.CustomException;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.BusinessLayer.Services
{
    public class RoomDetailService:IRoomDetailService
    {
        private readonly IRoomDetail roomDetailRepository;

        public RoomDetailService(IRoomDetail roomDetailRepository)
        {
            this.roomDetailRepository = roomDetailRepository;
        }

        public IEnumerable<RoomDetail> GetAllRooms()
        {
            try
            {
                return roomDetailRepository.GetAllRooms();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public RoomDetail GetRoomDetail(int id)
        {
            try
            {
                return roomDetailRepository.GetRoomDetail(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public RoomDetail AddRoom(RoomDetail rd)
        {
            try
            {
                return roomDetailRepository.AddRoom(rd);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public RoomDetail UpdateRoomDetail(RoomDetail rd, int id)
        {
            try
            {
                return roomDetailRepository.UpdateRoomDetail(rd, id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public RoomDetail DeleteRoom(int id)
        {
            try
            {
                return roomDetailRepository.DeleteRoom(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }
        public IEnumerable<RoomDetail> GetConferenceByLocation(string locationName)
        {
            var rooms = roomDetailRepository.GetAllRooms()
                          .Where(e => e.Location?.City?.ToLower() == locationName.ToLower())
                          .ToList();
            if (rooms == null)
            {
                throw new Exception($"No Room found In {locationName}");
            }
            return (rooms);
        }


    }
}
