using System;
using System.Collections.Generic;
using AutoMapper;
using DR.Rangow.Application.Interfaces;
using DR.Rangow.Application.ViewsModels;
using DR.Rangow.Domain.Interfaces;
using DR.Rangow.Domain.Models;
using DR.Rangow.Infra.Data.Repository;

namespace DR.Rangow.Application.Services
{
    public class ClienteAppService : AppServiceBase, IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteAppService()
        {
            _clienteRepository = new ClienteRepository();
        }

        //leitura
        public IEnumerable<ClienteViewModel> ObterAtivos()
        {
            //Listar uma lista de clientes para ClientesViewsModel
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterAtivos());
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorEmail(email));
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        //Escrita
        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel.Cliente);

        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
