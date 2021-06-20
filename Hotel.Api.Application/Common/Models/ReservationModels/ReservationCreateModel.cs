using Hotel.Api.Application.Common.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Api.Application.Common.Models.ReservationModels
{
    public class ReservationCreateModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        [FutureDate]
        public DateTime CheckInDate { get; set; }

        [Required]
        [FutureDate]
        public DateTime CheckOutDate { get; set; }
    }
}
