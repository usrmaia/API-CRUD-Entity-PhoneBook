using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp.Entities;

namespace MyApp.Context
{
    // Herda de EntityFrameworkCore
    public class PhoneBookContext : DbContext
    {
        // Aponta para o DB
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
        {

        }

        // Tabela
        public DbSet<Contact> Contacts { get; set; }
    }
}