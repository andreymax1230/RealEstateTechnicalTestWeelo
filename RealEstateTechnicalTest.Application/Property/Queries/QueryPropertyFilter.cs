using MediatR;
using RealEstateTechnicalTest.Application.Mapper;
using RealEstateTechnicalTest.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateTechnicalTest.Application.Property.Queries
{
    public class QueryPropertyFilter : IRequest<List<PropertyDto>>
    {
        public Guid? OwnerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal? Price { get; set; }
        public string CodeInternal { get; set; }
        public int? Year { get; set; }
    }

    public class QueryPropertyFilterHandler : IRequestHandler<QueryPropertyFilter, List<PropertyDto>>
    {
        private readonly IRepository<Domain.Entities.Property> _propertyRepository;

        public QueryPropertyFilterHandler(IRepository<Domain.Entities.Property> propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public Task<List<PropertyDto>> Handle(QueryPropertyFilter request, CancellationToken cancellationToken)
        {
            var list = _propertyRepository.GetMany(x => (!request.OwnerId.HasValue || x.OwnerId == request.OwnerId.Value)
                                                     && (string.IsNullOrEmpty(request.Name) || request.Name.ToUpper().Contains(x.Name.ToUpper()))
                                                     && (string.IsNullOrEmpty(request.Address) || request.Address.ToUpper().Contains(x.Address.ToUpper()))
                                                     && (!request.Price.HasValue || request.Price.Value == x.Price)
                                                     && (string.IsNullOrEmpty(request.CodeInternal) || request.CodeInternal.ToUpper().Contains(x.CodeInternal)
                                                     && (!request.Year.HasValue || request.Year.Value == x.Year)));
            var response = MapperConfig.Mapper.Map<List<PropertyDto>>(list);
            return Task.FromResult(response);
        }
    }
}
