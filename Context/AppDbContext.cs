﻿using APIProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace APIProdutos.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Produto> Produtos { get; set; }
}
