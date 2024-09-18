using EjemploCQRSMediatREF.DB.Command;
using EjemploCQRSMediatREF.DB.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EjemploCQRSMediatREF.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductoController : Controller
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public ProductoController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get([FromHeader]int idProducto)
        {
            var response = _mediator.Send(new GetProducto.ById(idProducto)).GetAwaiter().GetResult();
            var producto = response.Producto;
            return Json(producto);
        }

        [HttpGet]
        public IActionResult GetFirstByPrecio([FromHeader] decimal precioProducto)
        {
            var response = _mediator.Send(new GetProducto.ByPrecio(precioProducto)).GetAwaiter().GetResult();
            var producto = response.Producto;
            return Json(producto);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Producto Producto)
        {
            var response = _mediator.Send(new InsertProducto.Command(Producto)).GetAwaiter().GetResult();
            var productoInsertado = response.Producto;
            return Json(new { productoInsertado });
        }
    }
}