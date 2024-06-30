﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LogCargas.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O CPF do motorista é obrigatório", AllowEmptyStrings = false)]
        [Display(Name ="CPF")]
        [StringLength(11, ErrorMessage = "Tamanho informado incorreto")]
        public string CPF { get; set; }

        [Display(Name ="Celular")]
        [StringLength(11, ErrorMessage = "Tamanho informado incorreto")]
        [DataType(DataType.PhoneNumber)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "##-#####-####")]
        public string CelPhone { get; set; }

        // User ID form AspNetUser table
        public string? OwnerID { get; set; }

        public Driver ()
        {
        }

        public Driver(int id, string name, string cpf, string celPhone, string? ownerID)
        {
            Id = id;
            Name = name;
            CPF = cpf;
            CelPhone = celPhone;
            OwnerID = ownerID;
        }
    }
}
