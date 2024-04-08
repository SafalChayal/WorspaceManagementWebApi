using System.ComponentModel.DataAnnotations;

namespace WorkspaceManagement.DataAccessLayer.Models
{
    public class Location
    {
        [Key]
        public int Location_Id { get; set; }
        [Required]
        public string? FloorNumberOrBuildingName { get; set; }
        [Required]
        public string? StreetAddress { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public int Pincode { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public string? ImageData { get; set; }
        [Required]
        public int NumberOfConferenceRooms { get; set; }
        [Required]
        public int NumberOfDesk { get; set; }
        public ICollection<RoomDetail>? RoomDetail { get; set; }
        public ICollection<Employee>? Employee { get; set; }
        public ICollection<Events> ? Events { get; set; }   
        public ICollection<Notification>? Notification { get; set; }    

    }
}
