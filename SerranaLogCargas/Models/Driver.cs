﻿using System.ComponentModel.DataAnnotations;

namespace SerranaLogCargas.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Display(Name ="Celular")]
        [StringLength(11, ErrorMessage = "Tamanho informado incorreto")]
        [DataType(DataType.PhoneNumber)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "##-#####-####")]
        public string CelPhone { get; set; }

        public Driver ()
        {
        }

        public Driver(int id, string name, string celPhone)
        {
            Id = id;
            Name = name;
            CelPhone = celPhone;
        }
    }
}