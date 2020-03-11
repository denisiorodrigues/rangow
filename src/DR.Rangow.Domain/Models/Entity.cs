using System;
using System.Collections.Generic;

namespace DR.Rangow.Domain.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
            ValidationResult = new Dictionary<string, string>();
        }

        public Guid Id { get; set; }

        public IDictionary<string, string> ValidationResult { get; set; }

        public void AdicionarErroValidacao(string erro, string mensagem)
        {
            ValidationResult.Add(erro, mensagem);
        }

        public abstract bool EhValido();
    }
}
