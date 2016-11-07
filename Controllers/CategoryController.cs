using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using nsCategory;


[Route("/api/category")]
public class CategoryController : Controller {
    // Going to need some help with these 3 next lines; not super clear on the singleton stuff, I just made it C instead of P lol.
    // I'm guessing you're accessing the Product Singleton and calling it prodCont as in "Product Content"
    private ICategory categoryRepo;
    public CategoryController (ICategory c) {
        categoryRepo = c;
    }

    [HttpGet]
    public IActionResult GetAll() {
        return Ok(categoryRepo.getAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id = -1) {
        return Ok(categoryRepo.get(id));
    }

    [HttpPost]
    public IActionResult Add([FromBody] Category c) {
        categoryRepo.add(c);
        return Ok();
    }

    [HttpDelete("/{id}")]
    public IActionResult Delete(int id) {
        if (id != 0) { 
            if (categoryRepo.delete(id)) { 
                return Ok();
            } 
        }
        return NotFound();
    }

    [HttpPut("/{id}")]
    // syntax not super clear on this one for me, just the FromBody part
    public IActionResult Update(int id, [FromBody] Category c) {
        if (id != 0) { 
            return Ok(categoryRepo.update(id, c));
        }
        return NotFound();
    }
}