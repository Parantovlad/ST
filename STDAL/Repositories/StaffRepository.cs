using Microsoft.EntityFrameworkCore;
using STDAL.EF;
using STDAL.Entities;
using STDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STDAL.Repositories
{
    public class StaffRepository : BaseRepository<Staff>, IRepository<Staff>
    {
        public StaffRepository(STDBContext context)
        {
            Context = context;
            Table = context.Staff;
        }

        public IEnumerable<Staff> Find(Func<Staff, bool> predicate)
            => Context.Staff.Where(predicate).ToList();
    }
}
