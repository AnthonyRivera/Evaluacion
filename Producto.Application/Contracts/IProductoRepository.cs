using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Producto.Domain;

namespace Producto.Application.Contracts
{
    public interface IProductoRepository
    {
        void Add(Product producto);
        void Update(Product producto);
        void Delete(int id);
        Product GetById(int id);
        List<Product> GetAll();


    }
}
