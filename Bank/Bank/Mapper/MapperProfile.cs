using Application.DTO;
using AutoMapper;
using Bank.Models.ViewModels;

namespace Bank.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BalanceDto, BalanceViewModel>().
                ForMember(x => x.Balance, o => o.MapFrom(q => q.Balance)).
                ForMember(x => x.CardNumb, o => o.MapFrom(q => q.CardNumber)).
                ForMember(x => x.DateTime, o => o.MapFrom(q => q.Date));

            CreateMap<ReportDto, ReportViewModel>().
                ForMember(x => x.Balance, o => o.MapFrom(q => q.Balance)).
                ForMember(x => x.CardNumb, o => o.MapFrom(q => q.CardNumber)).
                ForMember(x => x.DateTime, o => o.MapFrom(q => q.Date)).
                ForMember(x => x.Widthdraw, o => o.MapFrom(q => q.Sum));
        }
    }
}
