using EjemploCQRSMediatREF.DB.Model;
using MediatR;

namespace EjemploCQRSMediatREF.DB.Command
{
    public class GetProducto
    {
        //Command
        public record ById(int Id):IRequest<Response>;
        //Handler
        public class Handler : IRequestHandler<ById, Response>
        {
            private readonly MainDbContext _ctx;

            public Handler(MainDbContext ctx)
            {
                _ctx = ctx;
            }

            public async Task<Response> Handle(ById request, CancellationToken cancellationToken)
            {
                var producto= _ctx.Productos.Find(request.Id);
                return new Response(producto);
            }
        }

        public record ByPrecio(decimal precio) : IRequest<Response>;

        public class ByPrecioHandler : IRequestHandler<ByPrecio, Response>
        {
            private readonly MainDbContext _ctx;

            public ByPrecioHandler(MainDbContext ctx)
            {
                _ctx = ctx;
            }

            public async Task<Response> Handle(ByPrecio request, CancellationToken cancellationToken)
            {
                var producto = _ctx.Productos.Where(x => x.Precio == request.precio).First();
                return new Response(producto);
            }
        }

        //Respuesta
        public record Response(Producto Producto);
    }
}
