using AutoMapper;
using KE.Entities.DbModels;
using KE.Entities.Emuns;
using KE.Entities.WsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KExpert.Ws.Mapping
{
    public class AutomapBootstrap
    {
        public static void InitializeMap()
        {
            Mapper.CreateMap<PolicyQuoteRequest, PolicyQuote>()
                .ForMember(d => d.Product_ID, o => o.MapFrom(s => s.Product))
                .ForMember(d => d.PolicyType_ID, o => o.MapFrom(s => s.PolicyType))
                .ForMember(d => d.PolicyPaymentMethod_ID, o => o.MapFrom(s => s.PolicyPaymentMethod))
                .ForMember(d => d.VehicleType_ID, o => o.MapFrom(s => s.VehicleType))
                .ForMember(d => d.VehicleUsage_ID, o => o.MapFrom(s => s.VehicleUsage))
                .ForMember(d => d.IsLegalPerson, o => o.MapFrom(s => s.IsLegalPerson ? LegalEntity.LegalPerson : LegalEntity.NaturalPerson))
                .ForMember(d => d.PolicyNrOfMonthsValid, o => o.MapFrom(s => s.PolicyNrOfMonthsValid))
                .ForMember(d => d.PolicyStartDate, o => o.MapFrom(s => new DateTimeOffset(s.PolicyStartingDate, TimeZoneInfo.Local.GetUtcOffset(s.PolicyStartingDate))))
                .ForMember(d => d.PolicyEndDate, o => o.MapFrom(s => new DateTimeOffset(s.PolicyStartingDate, TimeZoneInfo.Local.GetUtcOffset(s.PolicyStartingDate)).AddYears(1).AddDays(-1)))
                .ForMember(d => d.PostalCode, o => o.MapFrom(s => s.PostalCode))

                .ForMember(d => d.ID, o => o.Ignore())
                .ForMember(d => d.Guid, o => o.Ignore())
                .ForMember(d => d.Created, o => o.Ignore())
                .ForMember(d => d.Premium, o => o.Ignore())
                .ForMember(d => d.Broker_ID, o => o.Ignore())

                //.IgnoreAllUnmapped()
                .IgnoreAllVirtual();

            Mapper.CreateMap<PolicyQuote, PolicyQuoteResponse>()
                .ForMember(d => d.QuoteGuid, o => o.MapFrom(s => s.Guid))
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.Created.DateTime))
                .ForMember(d => d.Premium, o => o.MapFrom(s => s.Premium))
                .ForMember(d => d.PolicyStartingDate, o => o.MapFrom(s => s.PolicyStartDate.DateTime))
                .ForMember(d => d.PolicyEndingDate, o => o.MapFrom(s => s.PolicyEndDate.DateTime))
                .ForMember(d => d.PolicyQuoteRequest, o => o.Ignore())
                //.IgnoreAllUnmapped()
                .IgnoreAllVirtual();

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

        public static IMappingExpression<TSource, TDest> IgnoreAllUnmapped<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
        {
            expression.ForAllMembers(opt => opt.Ignore());
            return expression;
        }
    }
}