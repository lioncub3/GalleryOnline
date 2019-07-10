using GalleryOnline.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryOnline.Data
{
    public class GalleryContext: DbContext
    {
        public DbSet<Photo> Photos { get; set; }
        public GalleryContext(DbContextOptions options) : base(options) { }
    }
}
