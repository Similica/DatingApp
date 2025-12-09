using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options) 
  //DbContext is entity framework core
// : znaci da je AddDbContext derived iz DbContext
{
    public required DbSet<AppUser> Users { get; set; }  
    //Users sad mora biti ime tabele u bazi
    //<> ne oznacava niikakvu likstu nego samo parametar
}
