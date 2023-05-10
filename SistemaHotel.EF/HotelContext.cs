using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.EF.Contexto
{
    public partial class HotelContext : DbContext
    {
        private string _stringConnection;

        public HotelContext(string stringConnection)
        {
            _stringConnection = stringConnection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_stringConnection);
            }
        }
    }
}
