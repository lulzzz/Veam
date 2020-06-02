using System.Collections.Generic;
using System.Threading.Tasks;

namespace Veam.Application.Core
{
    public interface IBaseReadModelRepository
    {
        Task<IEnumerable<TReadModel>> GetAllAsync<TReadModel>(string sql, object parameters = null);
        Task<TReadModel> GetByIdAsync<TReadModel>(string sql, object parameters = null);
        IEnumerable<TReadModel> GetAll<TReadModel>(string sql, object parameters = null);
        TReadModel GetById<TReadModel>(string sql, object parameters = null);
    }
}
