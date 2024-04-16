using System.ComponentModel.DataAnnotations;

namespace SerranaLogCargas.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "CNPJ")]
        [StringLength(14, ErrorMessage = "Tamanho informado incorreto")]
        public string CNPJ { get; set; }
        [Display(Name = "Razão Social")]
        public string CorporateReason { get; set; }

        [Display(Name ="CCusto")]
        public string CostCenter { get; set; }

        public Customer() 
        {
        }

        public Customer(int id, string corporateReason, string cnpj, string costCenter)
        {
            Id = id;
            CorporateReason = corporateReason;
            CNPJ = cnpj;
            CostCenter = costCenter;
        }
    }
}
