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

            Mapper.CreateMap<AppUser, AppUserDto>().ReverseMap().IgnoreAllVirtual().IgnoreUnmappedProperties();
            Mapper.CreateMap<Broker, BrokerDto>().ReverseMap().IgnoreAllVirtual().IgnoreUnmappedProperties();
            
            Mapper.CreateMap<Policy, PolicyDto>()
                .ForMember(dest => dest.LastPolicyPeriod_ID, opts => opts.MapFrom(src => src.PolicyPeriods.FirstOrDefault(m => m.IsLastPeriod == true).ID))
                .ForMember(dest => dest.Broker, opts => opts.MapFrom(src => src.Broker.ToString()))
                .ForMember(dest => dest.Client, opts => opts.MapFrom(src => src.Client.ToString()))
                .ForMember(dest => dest.Vehicle, opts => opts.MapFrom(src => src.Vehicle.ToString()))
                .ForMember(dest => dest.Status, opts => opts.MapFrom(src => src.Status.Name))
                .ForMember(dest => dest.Product, opts => opts.MapFrom(src => src.Product.Name))
                .IgnoreAllVirtual()
                .IgnoreUnmappedProperties();
            Mapper.CreateMap<PolicyDto, Policy>()
               .IgnoreAllVirtual()
               .IgnoreUnmappedProperties();
            
            Mapper.CreateMap<PolicyPeriod, PolicyPeriodDto>()
                //.ForMember(dest => dest.NextPolicyPeriod_ID, opts => opts.MapFrom(src => src.))
                .ForMember(dest => dest.PaymentMethod, opts => opts.MapFrom(src => src.PaymentType.Name))
                .IgnoreAllVirtual()
                .IgnoreUnmappedProperties();
            Mapper.CreateMap<PolicyPeriodDto, PolicyPeriod>()
                //.ForMember(dest => dest.NextPolicyPeriod_ID, opts => opts.MapFrom(src => src.))
                .IgnoreAllVirtual()
                .IgnoreUnmappedProperties();

            Mapper.CreateMap<PolicyQuote, QuoteDto>().ReverseMap().IgnoreAllVirtual().IgnoreUnmappedProperties();


            Mapper.CreateMap<Vehicle, VehicleDto>()
                .ReverseMap()
                .IgnoreAllVirtual()
                .IgnoreUnmappedProperties();


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

        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);
            var existingMaps = Mapper.GetAllTypeMaps().First(x => x.SourceType.Equals(sourceType)
                && x.DestinationType.Equals(destinationType));
            foreach (var property in existingMaps.GetUnmappedPropertyNames())
            {
                expression.ForMember(property, opt => opt.Ignore());
            }
            return expression;
        }
    }
}
