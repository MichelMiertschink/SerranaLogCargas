﻿using LogCargas.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LogCargas.Models
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
        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }

        [Display(Name = "Origem")]
        public City CityOrigin { get; set; }
        [Display(Name = "Origem")]
        public int CityOriginId { get; set; }

        [Display(Name = "Destino")]
        public City CityDestiny { get; set; }
        [Display(Name = "Destino")]
        public int CityDestinyId { get; set; }

        [Display(Name = "Dt.Descarga")]
        [DataType(DataType.Date)]
        public DateTime UnloadDate { get; set; }
        [Display(Name ="PD")]
        // Peso de descarga necessário
        public bool PD { get; set; }

        [Display(Name = "Motorista")]
        public Driver Driver { get; set; }
        [Display(Name = "Motorista")]
        public int DriverId { get; set; }

        [Display(Name ="G")]
        public VehicleType VehicleType { get; set; }

        [Display(Name ="C")]
        public RiskManagement? RiskManagement { get; set; }

        // se é monitorado tem que ter Check list
        [Display(Name = "CK")]
        public bool CheckList { get; set; }

        [Display(Name ="M")]
        public bool Monitoring { get; set; }

        [Display(Name = "Peso")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public float Weigth { get; set; }

        [Display(Name = "Vl.Transp")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public float VlTranspor {  get; set; }

        [Display(Name = "Vl.Contr.")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public float VlContract {  get; set; }

        [Display(Name = "Vl.Adiant.")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public float Vladvance {  get; set; }

        [Display(Name = "R$")]
        public bool Pay {  get; set; }

        [Display(Name = "Contrato")]
        public int ContractId { get; set; }

        [Display(Name = "CTe")]
        public bool Cte {  get; set; }

        public LoadScheduling ()
        {
        }

        public LoadScheduling(int id, DateTime includeDate, bool bol, Customer customer, City cityOrigin, City cityDestiny, DateTime unloadDate, bool pD, Driver driver, VehicleType vehicleType, RiskManagement? riskManagement, bool checkList, bool monitoring, float weigth, float vlTranspor, float vlContract, float vladvance, bool pay, int contractId, bool cte)
        {
            Id = id;
            IncludeDate = includeDate;
            Bol = bol;
            Customer = customer;
            CityOrigin = cityOrigin;
            CityDestiny = cityDestiny;
            UnloadDate = unloadDate;
            PD = pD;
            Driver = driver;
            VehicleType = vehicleType;
            RiskManagement = riskManagement;
            CheckList = checkList;
            Monitoring = monitoring;
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
