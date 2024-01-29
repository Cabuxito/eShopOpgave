using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataLayer.JsonAPI
{
    public class PostNummerAPI
    {
        public string href { get; set; }
        public string nr { get; set; }
        public string navn { get; set; }
        public object stormodtageradresser { get; set; }
        public float[] bbox { get; set; }
        public float[] visueltcenter { get; set; }
        public Kommuner[] kommuner { get; set; }
        public DateTime ændret { get; set; }
        public DateTime geo_ændret { get; set; }
        public int geo_version { get; set; }
        public string dagi_id { get; set; }
    }

    public class Kommuner
    {
        public string href { get; set; }
        public string kode { get; set; }
        public string navn { get; set; }
    }

}
