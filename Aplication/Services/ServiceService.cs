using AutoMapper;
using CadDesigner.Aplication.DtoModels;
using CadDesigner.Aplication.Exceptions;
using CadDesigner.Domain.Entitys;
using CadDesigner.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace CadDesigner.Aplication.Services
{
    public interface IServiceService
    {
        Task<int> Create(int designerId, CreateServiceDto dto);
        Task<ServiceDto> GetById(int designerId, int serviceId);
        Task<IEnumerable<ServiceDto>> GetAll(int designerId);
        Task RemoveAll(int designerId);
        Task Delete(int serviceId, int designerId);
    }


    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        private readonly IDesignerRepository _designerRepository;


        public ServiceService(IServiceRepository serviceRepository, IDesignerRepository designerRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _designerRepository = designerRepository;
            _mapper = mapper;
        }


        public async Task<int> Create(int designerId, CreateServiceDto dto)
        {
            var designer = await _designerRepository.GetById(designerId) ?? throw new NotFoundException("Designer not found");


            var serviceEntity = _mapper.Map<Service>(dto);

            serviceEntity.DesignerId = designerId;


            await _serviceRepository.CreateAsync(serviceEntity);

            return serviceEntity.Id;
        }

        public async Task<ServiceDto> GetById(int designerId, int serviceId)
        {
            var designer = await _designerRepository.GetById(designerId) ?? throw new NotFoundException("Designer not found");

            var service = await _serviceRepository.GetByIdAsync(serviceId);

            if (service is null || service.DesignerId != designerId)
            {
                throw new NotFoundException("Services not found");
            }

            var serviceDto = _mapper.Map<ServiceDto>(service);
            return serviceDto;
        }


        public async Task RemoveAll(int designerId)
        {
            var designer = await _designerRepository.GetById(designerId) ?? throw new NotFoundException("Designer not found");
            var services = designer.Services.ToList() ?? throw new NotFoundException("Services not found");

            await _serviceRepository.RemoveAllAsync(services);
        }


       public async Task<IEnumerable<ServiceDto>> GetAll(int designerId)
        {
            var designer = await _designerRepository.GetById(designerId) ?? throw new NotFoundException("Designer not found");
            var service = designer.Services.ToList();

            var result = _mapper.Map<IEnumerable<ServiceDto>>(service);

            return result;
        }


        public async Task Delete(int designerId, int serviceId)
        {
           var designer = await _designerRepository.GetById(designerId) ?? throw new NotFoundException("Designer not found");
            var service = designer.Services.FirstOrDefault(s => s.Id == serviceId) ?? throw new NotFoundException("Service not found");
        
                await _serviceRepository.DeleteAsync(service);
        }
    }
}


