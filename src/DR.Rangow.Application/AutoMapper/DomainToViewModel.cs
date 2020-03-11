using AutoMapper;
using DR.Rangow.Application.ViewsModels;
using DR.Rangow.Domain.Models;

namespace DR.Rangow.Application.AutoMapper
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
        }
    }
}
