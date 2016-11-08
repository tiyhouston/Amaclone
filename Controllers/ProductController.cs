using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using nsRepoProduct;
using nsProduct;

[Route("/api/product")]
public class IProductController : Controller {
    
    private IProduct products;
    public IProductController (IProduct p) {
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

    [HttpDelete("/{id}")]
    public IActionResult Delete(int id) {
        if (id != 0) { 
            if (products.Delete(id)) { return Ok(); } 
        }
        return NotFound();
    }

    [HttpPut("/{id}")]
    public IActionResult Update(int id, [FromBody] Product p) {
        if (id != 0) { 
            return Ok(products.Update(id, p));
        }
        return NotFound();
    }

    [HttpGet("/search?")]
    public IActionResult Search(string term){
        if (term != 0)
            {return products.Search(term);}
        else {return NotFound();}
    }

}