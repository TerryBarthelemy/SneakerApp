using SneakerApp.DataAccess.Repository.IRepository;
using SneakerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerApp.DataAccess.Repository
{
    public class SneakerRepository : Repository<Sneaker>, ISneakerRepository
    {
        private ApplicationDbContext _db;
        public SneakerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Sneaker obj)
        {
            _db.Update(obj);
        }
    }
}
