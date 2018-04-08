using System;
using System.Collections.Generic;

namespace STDAL.Entities
{
    public partial class SubmissionRelations
    {
        public long ChiefId { get; set; }
        public long SubordinateId { get; set; }

        public Staff Chief { get; set; }
        public Staff Subordinate { get; set; }
    }
}
