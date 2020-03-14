namespace Data.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Khodro")]
    public class Khodro
    {
        public Khodro()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<KhodroProductRelation> ProductsRelation { get; set; }

        public virtual ICollection<AmarTolidKhodro> Tolids { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Sazandeh { get; set; }
    }
}