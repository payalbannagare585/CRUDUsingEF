using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDUsingEF.Models
{
    [Table("tblCategory")]
    public class Category
    {
     
        [System.ComponentModel.DataAnnotations.Key]
        [ScaffoldColumn(false)]
        public int CId { get; set; }
        [Required]

        public string CName { get; set; }   
    }
}
