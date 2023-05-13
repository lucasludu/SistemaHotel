using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Negocios.Context
{
    public static class EFStringConnection
    {
        public static IConfiguration Configuration { get; set; }

        /// <summary>
        /// Cadena de conexion tomada del appsettings.json en el formato necesario para EF
        /// </summary>
        public static string stringConnection { get; set; }

        /// <summary>
        /// Inicializa la cadena de conexion 
        /// </summary>
        /// <returns></returns>
        public static string GetStringConnection()
        {
            // Leo el archivo que contiene la cadena de conexion
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            string usarConnectionString = Configuration["ConnectionStringUsed"];
            stringConnection = Configuration.GetConnectionString(Configuration["ConnectionStringUsed"]);
            return stringConnection;
        }
    }
}
