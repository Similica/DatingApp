using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")] //localhost:5001/api/members 
    [ApiController] //atribut

    //vraca podatke u jsonu

    //ovo (AppDbContext context) je DEPENDENCY INJECTION!!
    //sada svi servisi u AppDbContextu su dostupni ovdje
    public class MembersController(AppDbContext context) : ControllerBase //mora se zvati ImenicaUMnoziniCOntroller
    {
        //ActionResult vraca http response 200,404,..etc
        //IReadOnlyList jer nam ne treba search sort manipulate
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members = await context.Users.ToListAsync();
 
            return members;
        }
// ovo je LINQ Language Integrated Query .toListAsync, .findAsync
//  LINQ --> Entity Framework prevede --> SQL
// prije njega moralo se ici kroz petlju za sve
        [HttpGet("{id}")] //localhost:5001/api/members/bob-id 
        public async Task<ActionResult<AppUser>> GetMember(string id)
        {
            var member = await context.Users.FindAsync(id);

            if(member == null) return NotFound();
            
            return member;
        }
    }

}
