
using Api.Rest.Entities;
using Api.Rest.Response;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Rest.Features.Product.Query
{
    public class QueryProductGetAllHandler : IRequestHandler<QueryProductGetAllRequest, Response<object>>
    {
        public readonly DatabaseContext _context;
        public QueryProductGetAllHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> Handle(QueryProductGetAllRequest request, CancellationToken cancellationToken)
        {
            var result =  _context.Products.Where(x => x.IsDelete == false).ToList();

            return new Response<object>(result);
        }
    }
    public class QueryProductGetAllRequest : IRequest<Response<object>>
    {
    }
}