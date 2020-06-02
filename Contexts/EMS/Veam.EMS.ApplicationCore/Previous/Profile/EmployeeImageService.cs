﻿using AutoMapper;
using System.Threading.Tasks;
using Veam.EMS.ApplicationCore.Interfaces.Repositories;
using Veam.EMS.ApplicationCore.Interfaces.Services;
using Veam.EMS.ApplicationCore.Models;
using Veam.EMS.Domain;

namespace Veam.EMS.ApplicationCore.Services
{
    public class EmployeeImageService : IEmployeeImageService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EmployeeImage> _repository;

        public EmployeeImageService(IAsyncRepository<EmployeeImage> repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeImage, EmployeeImageModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<EmployeeImageModel> AddAsync(EmployeeImageModel model)
        {
            var entity = new EmployeeImage
            {

                ImageId = model.ImageId,
                EmployeeId = model.EmployeeId,
                Images = model.Images
            };

            entity = await _repository.AddAsync(entity);
            return _mapper.Map<EmployeeImage, EmployeeImageModel>(entity);
        }

        public async Task<bool> ExistsAsync(string employeeId)
        {
            return await _repository.ExistsAsync(x => x.EmployeeId == employeeId);
        }

        public async Task<EmployeeImageModel> GetByEmployeeId(string employeeId)
        {
            var entity = await _repository.GetSingleAsync(x => x.EmployeeId == employeeId);
            return _mapper.Map<EmployeeImage, EmployeeImageModel>(entity);
        }

        public async Task UpdateAsync(EmployeeImageModel model)
        {
            var entity = await _repository.GetByIdAsync(model.ImageId);

            entity.EmployeeId = model.EmployeeId;
            entity.Images = model.Images;

            await _repository.UpdateAsync(entity);
        }
    }
}
