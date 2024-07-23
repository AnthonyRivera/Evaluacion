using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Producto.Application.Contracts;
using Producto.Domain;

namespace Producto.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController:ControllerBase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        [HttpGet(Name = "GetProductos")]
        public IEnumerable<Product> Get()
        {
            var contactsFromDb = _productoRepository.GetAll();
            return contactsFromDb;
        }

        [HttpGet("{id}", Name = "GetProducto")]
        public ActionResult<Product> Get(int id)
        {
            var productoFromDb = _productoRepository.GetById(id);
            if (productoFromDb == null)
            {
                return NotFound("Producto no encontrado");
            }
            return Ok(productoFromDb);
        }

        [HttpPost(Name = "CreateProducto")]
        public async Task<IActionResult> Create([FromBody] Product model)
        {
            if (model == null)
            {
                return BadRequest("Data de Producto es nula");
            }

            if (model.Precio < 0)
            {
                return BadRequest("El precio no puede ser negativo");
            }

            if (model.CantidadEnStock < 0)
            {
                return BadRequest("No puede haber cantidad negativa de producto");
            }



            if (ModelState.IsValid)
            {

                _productoRepository.Add(model);
                return CreatedAtRoute("GetProducto", new { id = model.Id }, model);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}", Name = "UpdateProducto")]
        public async Task<IActionResult> Update(int id, [FromBody] Product model)
        {
            if (model == null || id != model.Id)
            {
                return BadRequest("Data de producto es invalida");
            }

            if (model.Precio < 0)
            {
                return BadRequest("El precio no puede ser negativo");
            }

            if (model.CantidadEnStock < 0)
            {
                return BadRequest("No puede haber cantidad negativa de producto");
            }

            if (ModelState.IsValid)
            {
                _productoRepository.Update(model);
                return Ok(model);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}", Name = "DeleteProducto")]
        public async Task<IActionResult> Delete(int id)
        {
            var contactFromDb = _productoRepository.GetById(id);
            if (contactFromDb == null)
            {
                return NotFound("Producto no encontrado");
            }

            _productoRepository.Delete(contactFromDb.Id);
            return Ok("Producto Eliminado");
        }
    }
}
