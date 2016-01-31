using AutoMapper;
using KE.Entities.DbModels;
using KE.Entities.Emuns;
using KE.Entities.Models;
using KE.Entities.WsModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<Source, Dest>();
               
            });

            //IMapper mapper = config.CreateMapper();

            //QueryableExtensions.Factories.Configuration = () => config;   

            Mapper.CreateMap<AppUser, AppUserDto>().ReverseMap().IgnoreAllVirtual();
            Mapper.CreateMap<Broker, BrokerDto>().ReverseMap().IgnoreAllVirtual();
            //Mapper.CreateMap<Policy, PolicyDto>()
            //    .ForMember(dest => dest.LastPolicyPeriodID, opts => opts.MapFrom(src => src.PolicyPeriods.FirstOrDefault(m => m.IsLastPeriod == true).ID))
            //    .ReverseMap().IgnoreAllVirtual();
            //Mapper.CreateMap<PolicyPeriod, PolicyPeriodDto>().ReverseMap().IgnoreAllVirtual();
            Mapper.CreateMap<PolicyQuote, QuoteDto>().ReverseMap().IgnoreAllVirtual();



            Mapper.AssertConfigurationIsValid();
        }
    }

    public class KexpertProfile : Profile
    {
        protected override void Configure()
        {
            //Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }

    }
    public static class MappingExpressionExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllVirtual<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var desType = typeof(TDestination);
            foreach (var property in desType.GetProperties().Where(p =>
                                     p.GetGetMethod().IsVirtual))
            {
                expression.ForMember(property.Name, opt => opt.Ignore());
            }

            return expression;
        }

        public static IMappingExpression<TSource, TDestination> IgnoreUnmappedProperties<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var typeMap = Mapper.FindTypeMapFor<TSource, TDestination>();
            if (typeMap != null)
            {
                foreach (var unmappedPropertyName in typeMap.GetUnmappedPropertyNames())
                {
                    expression.ForMember(unmappedPropertyName, opt => opt.Ignore());
                }
            }

            return expression;
        }
    }
}
