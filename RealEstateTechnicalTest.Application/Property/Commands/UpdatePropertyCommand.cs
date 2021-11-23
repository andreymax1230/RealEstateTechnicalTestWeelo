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
    public class UpdatePropertyCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
    }

    public class UpdatePropertyCommandHandler : IRequestHandler<UpdatePropertyCommand, bool>
    {
        private readonly IRepository<Domain.Entities.Property> PropertyRepository;
        private readonly IUnitOfWork UnitOfWork;

        public UpdatePropertyCommandHandler(IRepository<Domain.Entities.Property> propertyRepository, 
                                            IUnitOfWork unitOfWork)
        {
            PropertyRepository = propertyRepository;
            UnitOfWork = unitOfWork;
        }


        public async Task<bool> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            var exist = PropertyRepository.Count(x => x.Id == request.Id);
            if (exist <= 0)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            var entity = MapperConfig.Mapper.Map<Domain.Entities.Property>(request);
            if (entity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            PropertyRepository.Update(entity);
            var response = await UnitOfWork.CommitAsync(cancellationToken);
            return response > 0;
        }
    }
}
