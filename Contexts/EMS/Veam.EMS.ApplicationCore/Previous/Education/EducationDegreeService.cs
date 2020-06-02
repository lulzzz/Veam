using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EMS.ApplicationCore.Interfaces.Repositories;
using Veam.EMS.ApplicationCore.Interfaces.Services;
using Veam.EMS.ApplicationCore.Models;
using Veam.EMS.Domain;

namespace Veam.EMS.ApplicationCore.Services
{
    public class EducationDegreeService : IEducationDegreeService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EducationDegree> _repository;

        public EducationDegreeService(IAsyncRepository<EducationDegree> repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EducationDegree, EducationDegreeModel>());

            _mapper = config.CreateMapper();
        }


        public async Task<EducationDegreeModel> GetByIdAsync(int id)
        {
            var degree = await _repository.GetByIdAsync(id);
            return _mapper.Map<EducationDegree, EducationDegreeModel>(degree);
        }

        public async Task<List<EducationDegreeModel>> GetAllAsync()
        {
            var degree = await _repository.GetAllAsync();
            return _mapper.Map<List<EducationDegree>, List<EducationDegreeModel>>(degree);
        }

        public async Task<List<EducationDegreeModel>> GetByNameAsync(string name)
        {
            var degree = await _repository.GetAsync(x => x.DegreeName.Contains(name));
            return _mapper.Map<List<EducationDegree>, List<EducationDegreeModel>>(degree);
        }

        public async Task<EducationDegreeModel> AddAsync(EducationDegreeModel model)
        {
            var degree = new EducationDegree
            {
                DegreeName = model.DegreeName,
                DegreeNameThai = model.DegreeNameThai
            };

            degree = await _repository.AddAsync(degree);
            return _mapper.Map<EducationDegree, EducationDegreeModel>(degree);
        }

        public async Task UpdateAsync(EducationDegreeModel model)
        {
            var degree = await _repository.GetByIdAsync(model.DegreeId);

            degree.DegreeName = model.DegreeName;
            degree.DegreeNameThai = model.DegreeNameThai;

            await _repository.UpdateAsync(degree);
        }

        public async Task DeleteAsync(int id)
        {
            var degree = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(degree);
        }
    }
}
