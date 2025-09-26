using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Application.CQRS
{
    public class CityCreateDTO
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public string CountryName { get; set; } // only country name
    }

}
