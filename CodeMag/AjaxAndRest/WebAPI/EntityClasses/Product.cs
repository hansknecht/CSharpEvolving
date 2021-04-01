using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI
{
    [Table("product", Schema="production")]
    public partial class Product
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productid {get; set; }
        [Required(ErrorMessage = "The Product Name is required")]
        public string name { get; set; }
        [Required]
        public string productnumber { get; set; }
        public string color { get; set; } 
        [Required]
        public decimal standardcost { get; set; }
        [Required]
        public decimal listprice { get; set; }
        public string size { get; set; }
        public decimal? weight { get; set; }
        public int? productsubcategoryid { get; set; }
        public int? productmodelid { get; set; }
        [Required]
        public DateTime sellstartdate { get; set; }
        public DateTime? sellenddate { get; set; }
        public DateTime? discontinueddate { get; set; }
        [Required]
        public Guid rowguid { get; set; }
        [Required]
        public DateTime modifieddate { get; set; }
        [Required]
        public int safetystocklevel { get; set; }
        [Required]
        public int reorderpoint { get; set; }
        [Required]
        public int daystomanufacture { get; set; }
    }

}