﻿using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EMS.ApplicationCore.Interfaces.Repositories;
using Veam.EMS.ApplicationCore.Interfaces.Services;
using Veam.EMS.ApplicationCore.Models;
using Veam.EMS.Domain;

namespace Veam.EMS.ApplicationCore.Services
{
    public class SkillGroupService : ISkillGroupService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MasterSkillGroup> _repository;

        public SkillGroupService(IAsyncRepository<MasterSkillGroup> repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MasterSkillGroup, SkillGroupModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<SkillGroupModel> GetByIdAsync(int id)
        {
            var skillGroup = await _repository.GetByIdAsync(id);
            return _mapper.Map<MasterSkillGroup, SkillGroupModel>(skillGroup);
        }

        public async Task<List<SkillGroupModel>> GetAllAsync()
        {
            var skillGroups = await _repository.GetAllAsync();
            return _mapper.Map<List<MasterSkillGroup>, List<SkillGroupModel>>(skillGroups);
        }

        public async Task AddAsync(SkillGroupModel model)
        {
            var skillGroup = new MasterSkillGroup
            {
                SkillGroupName = model.SkillGroupName
            };

            await _repository.AddAsync(skillGroup);
        }

        public async Task UpdateAsync(SkillGroupModel model)
        {
            var skillGroup = await _repository.GetByIdAsync(model.SkillGroupId);

            skillGroup.SkillGroupName = model.SkillGroupName;

            await _repository.UpdateAsync(skillGroup);
        }

        public async Task DeleteAsync(int id)
        {
            var skillGroup = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(skillGroup);
        }
    }
}
