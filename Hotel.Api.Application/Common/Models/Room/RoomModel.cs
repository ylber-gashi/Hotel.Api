﻿using Hotel.Api.Domain.Enumerations;
using System.Collections.Generic;

namespace Hotel.Api.Application.Common.Models.Room
{
    public class RoomModel
    {
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public int Capacity { get; set; }
        public RoomTypes RoomType { get; set; }
        public double Price { get; set; }

        public List<string> Images { get; set; }
    }
}