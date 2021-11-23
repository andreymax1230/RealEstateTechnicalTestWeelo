using MediatR;
using RealEstateTechnicalTest.Application.Mapper;
using RealEstateTechnicalTest.Domain.Repositories;
using RealEstateTechnicalTest.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateTechnicalTest.Application.Property.Commands
{
    public class CreatePropertyCommand: IRequest<bool>
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
    }

    public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, bool>
    {
        private readonly IRepository<Domain.Entities.Property> PropertyRepository;
        private readonly IUnitOfWork UnitOfWork;

        public CreatePropertyCommandHandler(IRepository<Domain.Entities.Property> propertyRepository, 
                                            IUnitOfWork unitOfWork)
        {
            PropertyRepository = propertyRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var entity = MapperConfig.Mapper.Map<Domain.Entities.Property>(request);
            if (entity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            entity.Id = Guid.NewGuid();
            PropertyRepository.Insert(entity);
            var response = await UnitOfWork.CommitAsync(cancellationToken);
            return response > 0;
        }
    }
}
