using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;

namespace SerranaLogCargas.Models
{
    public class LoadScheduling
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Dt. Inclusão")]
        [DataType(DataType.DateTime)]
        public DateTime IncludeDate { get; set; }

        [Display(Name = "BOL")]
        public bool Bol {  get; set; }

        [Display(Name = "Cliente")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        [Display(Name = "Origem")]
        public City CityOrigin { get; set; }
        public int CityOriginId { get; set; }
        
        [Display(Name = "Destino")]
        public City CityDestiny { get; set; }
        public int CityDestinyId { get; set; }

        [Display(Name = "Dt. Desc.")]
        [DataType(DataType.Date)]
        public DateTime UnloadDate { get; set; }
        [Display(Name ="PD")]
        // Peso de descarga necessário
        public bool PD { get; set; }

        

        // Vários campos com possíveis Enums
        // G = indica se é F=frota, T=terceio A = Agregado
        // C = R=Raster S=Skymark (gerenciadora de risco)
        // CK = Se tem que fazer checklistp do monitoramento
        // M = Monitorado (se for tem que ter CK)

        [Display(Name = "Peso")]
        public float Weigth { get; set; }

        [Display(Name = "Tranpor")]
        public float VlTranspor {  get; set; }

        [Display(Name = "Vl Contrato")]
        public float VlContract {  get; set; }

        [Display(Name = "Vl Adiant.")]
        public float Vladvance {  get; set; }

        [Display(Name = "R$")]
        public bool Pay {  get; set; }

        [Display(Name = "Contrato")]
        public int ContractId { get; set; }

        [Display(Name = "CT-e")]
        public bool Cte {  get; set; }

        public LoadScheduling ()
        {
        }

        public LoadScheduling(int id, DateTime includeDate, bool bol, Customer customer, City cityOrigin, City cityDestiny, DateTime unloadDate, bool pD, float weigth, float vlTranspor, float vlContract, float vladvance, bool pay, int contractId, bool cte)
        {
            Id = id;
            IncludeDate = includeDate;
            Bol = bol;
            Customer = customer;
            CityOrigin = cityOrigin;
            CityDestiny = cityDestiny;
            UnloadDate = unloadDate;
            PD = pD;
            Weigth = weigth;
            VlTranspor = vlTranspor;
            VlContract = vlContract;
            Vladvance = vladvance;
            Pay = pay;
            ContractId = contractId;
            Cte = cte;
        }
    }
}
