using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using nsStore;
using StoreRepo;

[Route("/api/store")]
public class StoreController : Controller {
    
    private IStore stores;
    public StoreController (IStore s) {
        stores = s;
    }

    [HttpGet]
    public IActionResult GetAll() {
        return Ok(stores.getAll());
    }

    [HttpPost]
    public IActionResult Add([FromBody] Store s) {
        stores.add(s);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
        if (id != 0) { 
            if (stores.delete(id)) { return Ok(); } 
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Store s) {
        if (id != 0) { 
            return Ok(stores.update(id, s));
        }
        return NotFound();
    }

    [HttpGet("{search}")]
    public IActionResult Search(string search){
        if (search != "")
            {return Ok(stores.search(search));}
        else {return NotFound();}
    }

}