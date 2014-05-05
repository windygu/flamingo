using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keygen
{
    public class CustomDataTypes
    {
        public class TheaterInfo
        {
            public string TheaterId { get; set; }
            public string TheaterName { get; set; }
            public string TheaterType { get; set; }
            public string Corporation { get; set; }
            public string Telephone { get; set; }
            public string Manager { get; set; }
            public int? Halls { get; set; }
            public int? Seats { get; set; }
            public string Province { get; set; }
            public string City { get; set; }
            public string District { get; set; }
            public string PostCode { get; set; }
            public string Address { get; set; }
            public string TheaterCode { get; set; }
            public string CineChainId { get; set; }
            public string SerialNumber { get; set; }
            public DateTime? Created { get; set; }
            public DateTime? Updated { get; set; }
            public string Rating { get; set; }
            public string Fax { get; set; }
            public string Mobile { get; set; }
            public string Version { get; set; }
          
            public string  ServerModle { get; set; }
            public string  ServerCPU { get; set; }
            public string  ServerMemory { get; set; }
            public string ServerHardDriver { get; set; }
            public int? Clients { get; set; }

        }

        public class HallInfo
        {

            public string HallId { get; set; }
            public string TheaterId { get; set; }
            public string HallName { get; set; }
            public int? Seats { get; set; }
            public int? Levels { get; set; }
            public string Screen { get; set; }
            public string Projector { get; set; }
            public string PlayMode { get; set; }
            public string SoundSystem { get; set; }
            public string Description { get; set; }
            public DateTime? Created { get; set; }
            public DateTime? Updated { get; set; }
            public bool? ActiveFlag { get; set; }
            public string BarColour { get; set; }
        }
    }
}
