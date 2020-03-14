namespace Data.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Pallet")]
    public class Pallet
    {
        public Pallet()
        {
            Products = new HashSet<Product>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        public byte Vazn { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}