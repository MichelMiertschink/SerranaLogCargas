using System.ComponentModel.DataAnnotations;

namespace SerranaLogCargas.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Razão Social")]
        public string CorporateReason { get; set; }
        [Required]
        [Display(Name = "CNPJ")]
        [StringLength(14, ErrorMessage = "Tamanho informado incorreto")]
        public string CNPJ { get; set; }
        [Required]
        [Display(Name ="CCusto")]
        public string CostCenter { get; set; }

        public Customer() { }

        public Customer(int id, string corporateReason, string cNPJ, string costCenter)
        {
            Id = id;
            CorporateReason = corporateReason;
            CNPJ = cNPJ;
            CostCenter = costCenter;
        }
    }
}
