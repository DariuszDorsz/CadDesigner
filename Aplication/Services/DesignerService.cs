using AutoMapper;
using CadDesigner.Aplication.DtoModels;
using CadDesigner.Aplication.Exceptions;
using CadDesigner.Domain.Entitys;
using CadDesigner.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;


namespace CadDesigner.Aplication.Services
{
    public interface IDesignerService
    {
        Task<DesignerDto> GetById(int id);
        Task<PagedResult<DesignerDto>> GetAll(DesignerQuery query);
        Task<int> Create(CreateDesignertDto dto);
        Task Delete(int id);
        Task Update(int id, UpdateDesignerDto dto);
    }


    public class DesignerService : IDesignerService
    {
        private readonly IDesignerRepository _designerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DesignerService> _logger;


        public DesignerService(IDesignerRepository designerRepository, IMapper mapper, ILogger<DesignerService> logger)
        {
            _designerRepository = designerRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<int> Create(CreateDesignertDto dto)
        {
            var designer = _mapper.Map<Designer>(dto);
            await _designerRepository.Create(designer);

            return designer.Id;
        }


        public async Task Update(int id, UpdateDesignerDto dto)
        {
            var designer = await _designerRepository.GetById(id)
                ?? throw new NotFoundException("Designer not found");

            if (designer.Name != null)
            {
                designer.Name = dto.Name;
            }
           if (designer.Description != null)
            {
                designer.Description = dto.Description;
            }
            
           if (designer != null)
            {
                await _designerRepository.Update(designer);
            }
           
        }


        public async Task Delete(int id)
        {
            _logger.LogError("Error", $"Designer with id: {id} DELETE action invoked");

            var designer = await _designerRepository.GetById(id)
                ?? throw new NotFoundException("Designer not found");

            await _designerRepository.Delete(designer);
        }


        public async Task<DesignerDto> GetById(int id)
        {
            var designer = await _designerRepository.GetById(id)
                ?? throw new NotFoundException("Designer not found");

            var result = _mapper.Map<DesignerDto>(designer);
            return result;
        }


        public async Task<PagedResult<DesignerDto>> GetAll(DesignerQuery query)
        {
            var allDesigners = await _designerRepository.GetAll();
            var baseQuery = allDesigners.Where(r => query.SearchPhrase == null || (r.Name.ToLower().Contains(query.SearchPhrase.ToLower())
                 || r.Description.ToLower().Contains(query.SearchPhrase.ToLower())));


            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<Designer, object>>>
                {
                    { nameof(Designer.Name), r => r.Name },
                    { nameof(Designer.Description), r => r.Description },
                    { nameof(Designer.Category), r => r.Category },
                };
            }

            var designer = baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();

            var totalItemsCount = baseQuery.Count();

            var designerDtos = _mapper.Map<List<DesignerDto>>(designer);

            var result = new PagedResult<DesignerDto>(designerDtos, totalItemsCount, query.PageSize, query.PageNumber);

            return result;
        }
    }
}
