﻿
using AppSix;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSix
{
    public class CrudContextFactory : IDesignTimeDbContextFactory<UserContext>
    {
     

        public UserContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString"));

            return new UserContext(optionsBuilder.Options);
        }
    }
}
