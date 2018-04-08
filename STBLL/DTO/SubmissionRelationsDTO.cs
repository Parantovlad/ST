using System;
using System.Collections.Generic;
using System.Text;

namespace STBLL.DTO
{
    public class SubmissionRelationsDTO
    {
        public long ChiefId { get; set; }
        public long SubordinateId { get; set; }

        public StaffDTO Chief { get; set; }
        public StaffDTO Subordinate { get; set; }
    }
}
