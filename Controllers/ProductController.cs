using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using nsRepoProduct;
using nsProduct;

[Route("/api/product")]
public class ProductController : Controller {
    
    private IProduct products;
    public ProductController (IProduct p) {
        products = p;
    }

    [HttpGet]
    public IActionResult GetAll() {
        return Ok(products.getAll());
    }

    [HttpPost]
    public IActionResult Add([FromBody] Product p) {
        products.add(p);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
        if (id != 0) { 
            if (products.delete(id)) { return Ok(); } 
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Product p) {
        if (id != 0) { 
            return Ok(products.update(id, p));
        }
        return NotFound();
    }

    [HttpGet("{search}")]
    public IActionResult Search(string search){
        if (search != "")
            {return Ok(products.search(search));}
        else {return NotFound();}
    }

}