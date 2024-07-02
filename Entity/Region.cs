using System;
namespace Entity
{
    public class Region
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public int Created { get; set; }
        public bool Enabled { get; set; }
    }
}
