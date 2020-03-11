﻿using System;
using System.Collections.Generic;

namespace DR.Rangow.Domain.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
        
        public void AdicionarEndereco(Endereco endereco)
        {
            if (!endereco.EhValido())
            {
                ValidationResult = endereco.ValidationResult;
                return;
            }

            Enderecos.Add(endereco);
        }

        public void DefinirComoExcluido()
        {
            this.Ativo = false;
            this.Excluido = true;
        }

        public void DefinirComoAtivo()
        {
            this.Ativo = true;
            this.Excluido = false;
        }

        public override bool EhValido()
        {
            if (string.IsNullOrWhiteSpace(Nome))
            {
                AdicionarErroValidacao("Nome", "O nome não pode estar vazio");
            }

            return ValidationResult.Count == 0;
        }
    }
}
