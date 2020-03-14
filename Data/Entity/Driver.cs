namespace Data.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Driver")]
    public class Driver
    {
        public Driver()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(12)]
        public string Tel1 { get; set; }

        [StringLength(12)]
        public string Tel2 { get; set; }

        [StringLength(10)]
        public string Pelak { get; set; }

        [StringLength(20)]
        public string Car { get; set; }

        public short? Ton { get; set; }

        public byte? Tol { get; set; }
        public bool isContainer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }

}