using System;
using System.Collections.Generic;
using System.Text;

namespace Veam.Centers.Application.CenterMap
{
    public class CenterCommandDto
    {
        public long CenterId { get; set; }
        public string CenterName { get; set; }

        //specific to command
        public int buildingId { get; set; }
        public int centerTypeId { get; set; }
        public int SubsideryId { get; set; }
        public string description { get; set; }
        public bool isHO { get; set; } = false;

        public string user { get; set; }
    }

}

