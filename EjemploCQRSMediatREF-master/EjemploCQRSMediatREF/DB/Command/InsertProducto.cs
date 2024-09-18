using EjemploCQRSMediatREF.DB.Model;
using MediatR;

namespace EjemploCQRSMediatREF.DB.Command
{
    public class InsertProducto
    {
        //Command
        public record Command(Producto Producto):IRequest<Response>;
        //Handler
        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly MainDbContext _ctx;

            public Handler(MainDbContext ctx)
            {
                _ctx = ctx;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                _ctx.Productos.Add(request.Producto);
                _ctx.SaveChanges();
                return new Response(request.Producto);
            }
        }

        //Respuesta
        public record Response(Producto Producto);
    }
}
