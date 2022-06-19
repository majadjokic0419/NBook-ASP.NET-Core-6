using NBook.DataAccess.Repository.IRepository;
using NBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBook.DataAccess.Repository
{
    internal class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        readonly private ApplicationDbContext _db;
        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CoverType obj)
        {
            _db.CoverTypes.Update(obj);
        }

       
    }
}
