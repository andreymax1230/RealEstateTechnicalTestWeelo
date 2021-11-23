using MediatR;
using RealEstateTechnicalTest.Application.Mapper;
using RealEstateTechnicalTest.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateTechnicalTest.Application.Owner.Queries
{
    public class OwnerQuery : IRequest<List<OwnerDto>>
    {
         
    }

    public class OwnerQueryHandler : IRequestHandler<OwnerQuery, List<OwnerDto>>
    {
        private readonly IRepository<Domain.Entities.Owner> _ownerRepository;
        public OwnerQueryHandler(IRepository<Domain.Entities.Owner> ownerRepository)
        {
            this._ownerRepository = ownerRepository;
        }

        public Task<List<OwnerDto>> Handle(OwnerQuery request, CancellationToken cancellationToken)
        {
            var list = _ownerRepository.GetAll();
            var response = MapperConfig.Mapper.Map<List<OwnerDto>>(list);
            return Task.FromResult(response);
        }
    }
}
