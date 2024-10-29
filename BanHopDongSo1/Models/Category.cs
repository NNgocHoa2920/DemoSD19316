using System.ComponentModel.DataAnnotations;

namespace BanHopDongSo1.Models
{
    public class Category
    {
        [Key]
        public int Ma { get; set; }
        [Required]
        [MaxLength(255)]
        [MinLength(3)]
        public string Name { get; set; }
        [Range(3,255,ErrorMessage ="Nhập từ 1-100 kí tự")]
        public string Description { get; set; }
    }
}
