using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChanInventorySystem.Services
{
    
    internal class ProductService
    {
        private readonly string _connectionString;

        public ProductService()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["KenchanDB"].ConnectionString;
        }
    }
}
