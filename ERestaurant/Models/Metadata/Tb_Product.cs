using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ERestaurant.Models.Metadata
{
    public class Tb_Product
    {
        public int Id { get; set; }
        [DisplayName("Danh muc san pham")]
        [Required(ErrorMessage = "Phai chon danh muc san pham")]
        public Nullable<int> Category_id { get; set; }
        [Required(ErrorMessage = "Ten san pham bat buoc phai nhap")]
        [DisplayName("Ten san pham")]
        public string Name { get; set; }
        [DisplayName("Gia cho 1 don vi SP:")]
        [Required(ErrorMessage = "Gia khong duoc bo trong")]
        [DataType(DataType.Currency, ErrorMessage = "Du lieu khong dung dinh dang")]
        public Nullable<decimal> Price { get; set; }
        [DisplayName("Mo ta san pham")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Image { get; set; }
        public Nullable<int> Active { get; set; }

        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_items> Order_items { get; set; }
    }
}