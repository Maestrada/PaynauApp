using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PaynauApp_Domain.Entities;
using PaynauApp_Infrastructure;

namespace PaynauApp_Application.Queries
{
    public class GetPersonasQuery : IRequest<List<Persona>> { }

    public class GetPersonasQueryHandler : IRequestHandler<GetPersonasQuery, List<Persona>>
    {
        private readonly PaynauContext _context;

        public GetPersonasQueryHandler(PaynauContext context)
        {
            _context = context;
        }

        public async Task<List<Persona>> Handle(GetPersonasQuery request, CancellationToken cancellationToken)
        {
            return await _context.Personas.ToListAsync(cancellationToken);
        }
    }
}
