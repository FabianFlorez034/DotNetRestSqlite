using Api.Rest.Dto;
using Api.Rest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Rest.IServices
{
    public class ProductService : IProductService
    {
        public readonly DatabaseContext _context;
        public ProductService(DatabaseContext context)
        {
            _context = context;
        }

        public ProductDto Create(ProductDto dto)
        {
            var product = new Product();
            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Quantity = dto.Quantity;
            _context.Products.Add(product);
            _context.SaveChanges();

            return dto;
        }

        public object GetById(int id)
        {
            Product findProduct = _context.Products.SingleOrDefault(x => x.Id == id && x.IsDelete == false);
            if (findProduct is null)
                return $"El producto con código: {id} no existe.";


            return findProduct;
        }

        public IEnumerable<Product> GetAll() => _context.Products.Where(x => x.IsDelete == false).ToList();


        public object Update(int id, ProductDto dto)
        {
            Product findProduct = _context.Products.SingleOrDefault(x => x.Id == id && x.IsDelete == false);

            if (findProduct is null)
                return $"El producto con código: {id} no existe.";

            findProduct.Name = dto.Name;
            findProduct.Price = dto.Price;
            findProduct.Quantity = dto.Quantity;

            var result = _context.SaveChanges();

            return result;
        }

        public object Delete(int id)
        {
            Product UpdateToProduct = _context.Products.SingleOrDefault(x => x.Id == id && x.IsDelete == false);

            if (UpdateToProduct is null)
                return $"El producto con código: {id} no existe.";

            UpdateToProduct.IsDelete = true;

            _context.SaveChanges();
            return $"El producto con código: {id} fue eliminado exitosamente.";
        }
    }
}
