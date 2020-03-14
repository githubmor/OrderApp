namespace Data.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Bazres")]
    public class Bazres
    {
        public Bazres()
        {
            Products = new HashSet<Product>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}