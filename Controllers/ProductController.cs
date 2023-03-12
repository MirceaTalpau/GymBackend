using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ogen.Models;
using Ogen.Data;

namespace Ogen.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApiContext _context;

        public ProductController(ApiContext context)
        {
            _context = context;
        }

        // Create/Edit
        [HttpPost]
        public ActionResult CreateEdit(Product product)
        {
            if(product.Id == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                var productInDb = _context.Products.Find(product.Id);

                if (productInDb == null)
                {
                    return new JsonResult(NotFound());
                }

                productInDb.Type = product.Type;
                productInDb.Name = product.Name;
                productInDb.Producer = product.Producer;
                productInDb.Size = product.Size;
                productInDb.Flavor = product.Flavor;
                productInDb.Stock = product.Stock;
                _context.Update(productInDb);
            }

            _context.SaveChanges();

            return new JsonResult(Ok(product));
        }

        // Buy

        [HttpPut]
        public IActionResult Buy(Product product)
        {
            if(product == null)
            {
                return new JsonResult(NotFound());
            }

            var productInDb = _context.Products.Find(product.Id);
            if (productInDb == null)
            {
                return new NotFoundResult();
            }

            productInDb.Stock -= product.Stock;

            _context.Update(productInDb);
            _context.SaveChanges();

            return new JsonResult(Ok(product));

        }

        // Get
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _context.Products.Find(id);

            if(result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));

        }

        // GetAll
        [HttpGet()]
        public ActionResult Get()
        {
            var result = _context.Products.ToList();
            return new JsonResult(Ok(result));
        }

        // Delete

        [HttpDelete] 
        public ActionResult Delete(int id) 
        {
            var product = _context.Products.Find(id);

            if(product == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Remove(product);
            _context.SaveChanges();
            return new JsonResult(Ok(product));
        }

    }
}
