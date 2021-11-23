using MediatR;
using RealEstateTechnicalTest.Domain.Repositories;
using RealEstateTechnicalTest.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateTechnicalTest.Application.Property.Commands
{
    public class UpdatePricePropertyCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
    }

    public class UpdatePricePropertyCommandHandle : IRequestHandler<UpdatePricePropertyCommand, bool>
    {
        private readonly IRepository<Domain.Entities.Property> PropertyRepository;
        private readonly IUnitOfWork UnitOfWork;

        public UpdatePricePropertyCommandHandle(IRepository<Domain.Entities.Property> propertyRepository,
                                                IUnitOfWork unitOfWork)
        {
            PropertyRepository = propertyRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdatePricePropertyCommand request, CancellationToken cancellationToken)
        {
            var entity = PropertyRepository.GetById(request.Id);
            if (entity is null)
            {
                throw new ApplicationException("Entity does not exist");
            }
            entity.Price = request.Price;
            PropertyRepository.Update(entity);
            var response = await UnitOfWork.CommitAsync(cancellationToken);
            return response > 0;
        }
    }
}
