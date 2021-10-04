using Api.Rest.Dto;
using Api.Rest.Entities;
using System.Collections.Generic;

namespace Api.Rest.IServices
{
    public interface IProductService
    {
        ProductDto Create(ProductDto product);
        object Update(int id,ProductDto dto);
        object GetById(int id);
        IEnumerable<Product> GetAll();
        object Delete(int id);
    }
}
