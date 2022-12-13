using SneakerApp.DataAccess.Repository.IRepository;
using SneakerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerApp.DataAccess.Repository
{
    public class SneakerSizeRepository : Repository<SneakerSize>, ISneakerSizeRepository
    {
        private ApplicationDbContext _db;
        public SneakerSizeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SneakerSize obj)
        {
            _db.SneakerSizes.Update(obj);
        }
    }
}
