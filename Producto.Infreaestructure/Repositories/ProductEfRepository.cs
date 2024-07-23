using Producto.Application.Contracts;
using Producto.Domain;
using Producto.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Infreaestructure.Repositories
{
    public class ProductEfRepository : IProductoRepository
    {
        private readonly ApplicationContext _context;

        public ProductEfRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Add(Product producto)
        {
            _context.productos.Add(producto);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var productosFromDb = GetById(id);
            if (productosFromDb != null)
            {
                _context.Remove(productosFromDb);
                _context.SaveChanges();
            }
        }

        public List<Product> GetAll()
        {
            return _context.productos.ToList();
        }

        public Product GetById(int id)
        {
            return _context.productos.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Product producto)
        {
            var productosFromDb = GetById(producto.Id);
            if (productosFromDb != null)
            {
                productosFromDb.Nombre = producto.Nombre;
                productosFromDb.Descripcion = producto.Descripcion;
                productosFromDb.Precio = producto.Precio;
                productosFromDb.CantidadEnStock = producto.CantidadEnStock;

                _context.productos.Update(productosFromDb);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException("Producto Not Found");
            }
            
        }
    }
}
