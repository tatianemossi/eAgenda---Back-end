using AutoMapper;
using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Dominio.ModuloContato;
using eAgenda.Webapi.ViewModels.ModuloCompromisso;
using eAgenda.Webapi.ViewModels.ModuloContato;
using System;

namespace eAgenda.Webapi.Config.AutoMapperConfig
{
    public class CompromissoProfile : Profile
    {
        public CompromissoProfile()
        {
            CreateMap<FormsCompromissoViewModel, Compromisso>()
                .ForMember(destino => destino.UsuarioId, opt => opt.MapFrom<UsuarioResolver>())
                .ForMember(destino => destino.Id, opt => opt.Ignore())
                .ForMember(destino => destino.HoraInicio, opt => opt.MapFrom(origem => TimeSpan.Parse(origem.HoraInicio)))
                .ForMember(destino => destino.HoraTermino, opt => opt.MapFrom(origem => TimeSpan.Parse(origem.HoraTermino)));

            CreateMap<Compromisso, ListarCompromissoViewModel>()
                .ForMember(d => d.Data, opt => opt.MapFrom(o => o.Data.ToShortDateString()))
                .ForMember(d => d.HoraInicio, opt => opt.MapFrom(o => o.HoraInicio.ToString(@"hh\:mm\:ss")))
                .ForMember(d => d.HoraTermino, opt => opt.MapFrom(o => o.HoraTermino.ToString(@"hh\:mm\:ss")))
                .ForMember(d => d.NomeContato, opt => opt.MapFrom(o => o.Contato.Nome));

            CreateMap<Compromisso, VisualizarCompromissoViewModel>();
            CreateMap<Compromisso, FormsCompromissoViewModel>();
            CreateMap<Contato, FormsContatoViewModel>();
        }
    }
}
