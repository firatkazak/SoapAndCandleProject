using System.ComponentModel.DataAnnotations;

namespace FratSCWeb_Models
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen isim giriniz...")]
        public string Name { get; set; }
    }
}
