using System.ComponentModel.DataAnnotations;

namespace CRUDTodos.Models
{
    public class User
    {
        [Required(ErrorMessage ="Le login est obligatoire")]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Le Password est obligatoire")]
        public string Password { get; set; }
    }
}
