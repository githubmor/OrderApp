namespace Data.Entity
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("KhodroProductRelation")]
    public class KhodroProductRelation
    {
        public KhodroProductRelation()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DefaultValue(1)]
        public byte Zarib { get; set; }

        public int KhodroId { get; set; }
        public virtual Khodro Khodro { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}