﻿using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.Models
{
    public class AzureDbContext : DbContext
    {
        public DbSet<> MyProperty { get; set; }
    }
}