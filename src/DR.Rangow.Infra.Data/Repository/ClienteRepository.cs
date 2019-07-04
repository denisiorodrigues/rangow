using System;
using System.Collections.Generic;
using System.Linq;
using DR.Rangow.Domain.Interfaces;
using DR.Rangow.Domain.Models;

namespace DR.Rangow.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public IEnumerable<Cliente> ObterAtivos()
        {
            return Buscar(c => c.Ativo == true);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public new Cliente ObterPorId(Guid id)
        {
            return Db.Clientes.AsNoTracking().Include("Endereco").FirstOrDefault(c => c.Id == id);
        }

        public new void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.DefinirComoExcluido();
            Atualizar(cliente);
        }
    }
}
