using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using nsRepoCategory;


[Route("/api/category")]
public class ICategoryController : Controller {
    // Going to need some help with these 3 next lines; not super clear on the singleton stuff, I just made it C instead of P lol.
    // I'm guessing you're accessing the Product Singleton and calling it prodCont as in "Product Content"
    private ICategory catCont;
    public ICategoryController (ICategory singletonC) {
        catCont = singletonC;
    }

    [HttpGet("/")]
    public IActionResult GetAll() {
        return Ok(catCont.getAll());
    }

    [HttpPost("/")]
    public IActionResult Add(List<Category> c) {
        // why does it need to check if there's at least 1?
        if (c.count > 0) {catCont.add(c)}
        return Ok(catCont.getAll());
    }

    [HttpDelete("/{id}")]
    public IActionResult Delete(int id) {
        if (id != "") { 
            if (catCont.delete(id)) { return Ok(catCont.getAll()); } 
        }
        return NotFound();
    }

    [HttpPut("/{id}")]
    // syntax not super clear on this one for me, just the FromBody part
    public IActionResult Update(int id, [FromBody] newC) {
        if (id != "") { 
            return Ok(prodCont.update(id, newC));
        }
        return NotFound();
    }
}