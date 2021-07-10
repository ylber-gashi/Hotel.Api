using Hotel.Api.Application.Common.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Api.Application.Common.Models.ReservationModels
{
    public class ReservationCreateModel : IValidatableObject
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CheckInDate < CheckOutDate)
            {
                yield return new ValidationResult(
                    errorMessage: "CheckOutDate must be greater than CheckInDate",
                    memberNames: new[] { "CheckOutDate" }
               );
            }
        }
    }
}
