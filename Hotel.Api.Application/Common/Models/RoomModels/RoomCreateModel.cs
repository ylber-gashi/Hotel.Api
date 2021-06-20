using Hotel.Api.Domain.Enumerations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Api.Application.Common.Models.RoomModels
{
    public class RoomCreateModel
    {
        [Required]
        [Range(0,int.MaxValue)]
        public int RoomNumber { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int FloorNumber { get; set; }
        [Required]
        [Range(1, 5)]
        public int Capacity { get; set; }
        [Required]
        public RoomTypes RoomType { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Required]
        public List<string> FirstImage { get; set; } = new List<string>();
    }
}
