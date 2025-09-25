using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Domain
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Population { get; set; }
        
        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}
