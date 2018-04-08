using STBLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace STBLL.Interfaces
{
    public interface IStaffService
    {
        void AddStaff(StaffDTO staff);
        StaffDTO GetStaff(int? id);
        IEnumerable<StaffDTO> GetStaffs(DateTime date);
        void Dispose();
    }
}
