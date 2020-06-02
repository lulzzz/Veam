using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veam.Centers.Domain;

namespace Veam.Centers.Application
{
    public interface IHallService
    {
        IQueryable<Hall> GetListqery();
        Task<IEnumerable<Hall>> GetList();
        IEnumerable<Hall> GetListByMaserId(long? masterid);
        Task<Hall> GetByIdAsync(long? id);
        IEnumerable<Center> GetCenterList();
    }
}
