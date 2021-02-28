using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemySwagger2.Models;

namespace UdemySwagger2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly UdemyContext _context;

        public ProductsController(UdemyContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Bu endpoint tüm ürünleri list olarak geri döner
        /// </summary>
        /// <remark>
        /// örnek: https://localhost:44339/api/values/products
        /// </remark>
        /// <returns></returns>
        [Produces("application/json")] // geriye dönüş tipi        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }

       /// <summary>
       /// BU endpoint verilen id'ye sahip ürünü döner.
       /// </summary>
       /// <param name="id">ürünün id'si</param>
       /// <returns></returns>
       ///<response code="404">Verilen id'ye sahip ürün kodu bulunamadı</response>
       ///<response code="200">Verilen id'ye sahip ürün var</response>
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Bu endpoint ürün ekler
        /// </summary>
        /// <remarks>
        /// örnek: product json:{...}
        /// </remarks>
        /// <param name="product"></param>
        /// <returns></returns>
        [Consumes("application/json")] // Beklenen tip
        [Produces("application/json")] // geriye dönüş tipi 
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            product.Date = DateTime.Now;
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
