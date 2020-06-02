﻿using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EMS.ApplicationCore.Interfaces.Repositories;
using Veam.EMS.ApplicationCore.Interfaces.Services;
using Veam.EMS.ApplicationCore.Models;
using Veam.EMS.Domain;

namespace Veam.EMS.ApplicationCore.Services
{
    public class SkillTypeService : ISkillTypeService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MasterSkillType> _repository;

        public SkillTypeService(IAsyncRepository<MasterSkillType> repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MasterSkillType, SkillTypeModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<SkillTypeModel> GetByIdAsync(int id)
        {
            var skillType = await _repository.GetByIdAsync(id);
            return _mapper.Map<MasterSkillType, SkillTypeModel>(skillType);
        }

        public async Task<List<SkillTypeModel>> GetAllAsync()
        {
            var skillTypes = await _repository.GetAllAsync();
            return _mapper.Map<List<MasterSkillType>, List<SkillTypeModel>>(skillTypes);
        }

        public async Task AddAsync(SkillTypeModel model)
        {
            var skillType = new MasterSkillType
            {
                SkillTypeName = model.SkillTypeName
            };

            await _repository.AddAsync(skillType);
        }

        public async Task UpdateAsync(SkillTypeModel model)
        {
            var skillType = await _repository.GetByIdAsync(model.SkillTypeId);

            skillType.SkillTypeName = model.SkillTypeName;

            await _repository.UpdateAsync(skillType);
        }

        public async Task DeleteAsync(int id)
        {
            var skillType = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(skillType);
        }
    }
}
