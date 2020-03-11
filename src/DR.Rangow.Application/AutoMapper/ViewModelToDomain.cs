using AutoMapper;

namespace DR.Rangow.Application.AutoMapper
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            //Não precisa por conta do método reverse do AutoMapper
            //CreateMap<ClienteViewModel, Cliente>();
            //CreateMap<EnderecoViewModel, Endereco>();
        }
    }
}
