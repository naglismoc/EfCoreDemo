using DataAcccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EfCoreDemo
{
    public class SakilaDBContextFactory : IDesignTimeDbContextFactory<SakilaDBContext>
    {
        public SakilaDBContext CreateDbContext(string[] args)
        {
            // konfiguracijos uskelimas is appsettings.josn
            IConfigurationRoot confoguration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            //connection string pasiemimas
            string connectionString = confoguration.GetConnectionString("DefaultConnection") ?? "";
            var builder = new DbContextOptionsBuilder<SakilaDBContext>();
            builder.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 4, 28)));
            return new SakilaDBContext(builder.Options);
        }
    }
}
