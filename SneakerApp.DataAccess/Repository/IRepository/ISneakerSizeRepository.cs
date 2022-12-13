using SneakerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerApp.DataAccess.Repository.IRepository
{
    public interface ISneakerSizeRepository : IRepository<SneakerSize>
    {
        void Update(SneakerSize obj);
    }
}
