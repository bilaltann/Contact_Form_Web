using System.ComponentModel.DataAnnotations.Schema;

namespace IletisimForm.Models
{
    public enum Department
    {
        Muhasebe,
        TeknikDestek,
        InsanKaynaklari,
    }
    public class User
    {
        public int Id { get; set; }


        public string? FirstName { get; set; }
        
        public string? Telephone { get; set; }
        public string? Eposta { get; set; }


        [Column(TypeName="string")]
        public string? Department { get; set; }   
        
        public string? Message { get; set; }
    }
}
