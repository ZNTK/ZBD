﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBD.WAPI.Models
{
    public class Bus : Base
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public decimal? Length { get; set; }

        public decimal? Width { get; set; }

        public int? Seats { get; set; }

        public IList<Passenger> Passengers { get; set; }
    }
}
