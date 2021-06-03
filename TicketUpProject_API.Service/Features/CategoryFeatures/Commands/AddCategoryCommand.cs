using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketUpProject_API.Domain.Entities;
using TicketUpProject_API.Persistence;

namespace TicketUpProject_API.Service.Features.CategoryFeatures.Commands
{
    public class AddCategoryCommand : IRequest<int>
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public class AddCategoryComandHandler : IRequestHandler<AddCategoryCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public AddCategoryComandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = new Category();

                category.CategoryName = request.CategoryName;
                category.Description = request.Description;

                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return category.Id;
            }
        }
    }
}
