using STDAL.EF;
using STDAL.Entities;
using STDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STDAL.Repositories
{
    public class SubmissionRelationsRepository : BaseRepository<SubmissionRelations>, IRepository<SubmissionRelations>
    {
        public SubmissionRelationsRepository(STDBContext context)
        {
            Context = context;
            Table = Context.SubmissionRelations;
        }

        public IEnumerable<SubmissionRelations> Find(Func<SubmissionRelations, bool> predicate)
            => Context.SubmissionRelations.Where(predicate).ToList();
    }
}
