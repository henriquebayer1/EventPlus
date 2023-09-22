﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.manha.Domains
{
    [Index(nameof(CNPJ), IsUnique = true)]
    [Table(nameof(Instituicao))]
    public class Instituicao
    {

        [Key]
        public Guid IdInstituicao { get; set; } = Guid.NewGuid();


        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "CNPJ e obrigatorio!")]
        [StringLength(14)]
        public string? CNPJ { get; set; }


        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "Endereco e obrigatorio!")]

        public string? Endereco { get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome fantasia e obrigatorio!")]

        public string? NomeFantasia { get; set; }


    }
}
