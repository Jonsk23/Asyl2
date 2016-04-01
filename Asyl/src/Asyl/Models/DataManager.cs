using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.Models
{
    public class DataManager
    {
        AzureDbContext context;

        public DataManager(AzureDbContext context)
        {
            this.context = context;
        }


    }
}
