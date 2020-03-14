namespace Data.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AmarTolidKhodro")]
    public class AmarTolidKhodro
    {
        public int TedadTolid { get; set; }

        [Key, Column(Order = 0)]
        public short SalMah { get; set; }

        [Key, Column(Order = 1)]
        public int KhodroId { get; set; }

        public virtual Khodro Khodro { get; set; }
    }
}