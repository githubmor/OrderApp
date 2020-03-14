namespace Data.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Order")]
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int SalMahRoz { get; set; }

        public bool Accepted { get; set; }
        public string Description { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}