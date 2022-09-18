using AutoMapper;
using CVSite.Application.Common.Interfaces;
using CVSite.Application.CV.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CVSite.Application.CV.Queries;

public static class GetCVQuery
{
    //Data we need to execute  
    public record Query(int id) : IRequest<Response>;

    //Writing Business logic and returns response.  
    public class Handler : IRequestHandler<Query, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Handler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response> Handle(Query query, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.EntityRepository.GetAsync(query.id, cancellationToken);
            return new Response(_mapper.Map<CurriculumVitaeDetailsDTO>(result));
        }
    }

    //Data we want to return  
    public record Response(CurriculumVitaeDetailsDTO DTO);
}