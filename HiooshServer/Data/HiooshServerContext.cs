#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HiooshServer.Models;

namespace HiooshServer.Data
{
    public class HiooshServerContext : DbContext
    {
        public HiooshServerContext (DbContextOptions<HiooshServerContext> options)
            : base(options)
        {
        }

        public DbSet<HiooshServer.Models.Rating> Rating { get; set; }
    }
}
