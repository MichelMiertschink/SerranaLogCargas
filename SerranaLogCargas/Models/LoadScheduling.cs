using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;

namespace SerranaLogCargas.Models
{
    public class LoadScheduling
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Dt. Inclusão")]
        public DateTime IncludeDate { get; set; }

        [Display(Name = "BOL")]
        public bool Bol {  get; set; }

        [Display(Name = "Cliente")]
        public Customer Customer { get; set; }
        public int CustomerId {  get; set; }

        [Display(Name = "Origem")]
        public City CityOrigin {  get; set; }
        public int OriginId { get; set; }
        
        [Display(Name = "Destino")]
        public City CityDestiny { get; set; }
        public int DestinyId { get; set; }

        [Display(Name = "Dt. Desc.")]
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

    }
}
