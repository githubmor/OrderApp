using System.Collections.Generic;

namespace OrderAndisheh.Domain.Entity
{
    public class TolidMahaneEntity
    {
        public int Mah { get; set; }
        public List<AmarTolidEntity> AmarTolids { get; set; }
    }
}