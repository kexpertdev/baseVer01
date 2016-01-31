using AutoMapper;
using KE.Entities.DbModels;
using KE.Entities.Models;
using KE.Entities.Emuns;
using KE.Entities.WsModels;
using KE.Entities.WsModels.Base;
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
                .ForMember(d => d.InsuranceCompany, o => o.MapFrom(s => s.InsuranceCompany))
                .ForMember(d => d.InsurancePolicyNumber, o => o.MapFrom(s => s.InsurancePolicyNumber))
                .ForMember(d => d.InsuranceStartDate, o => o.MapFrom(s => new DateTimeOffset(s.InsuranceStartDate, TimeZoneInfo.Local.GetUtcOffset(s.InsuranceStartDate))))
                .ForMember(d => d.InsuranceEndDate, o => o.MapFrom(s => new DateTimeOffset(s.InsuranceEndDate, TimeZoneInfo.Local.GetUtcOffset(s.InsuranceEndDate))))
                .IgnoreAllVirtual()
                .IgnoreUnmappedProperties();

            Mapper.CreateMap<PolicyQuote, PolicyQuoteResponse>()
                .ForMember(d => d.QuoteGuid, o => o.MapFrom(s => s.Guid))
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.Created.DateTime))
                .ForMember(d => d.Premium, o => o.MapFrom(s => s.Premium))
                //.ForMember(d => d.PolicyStartingDate, o => o.MapFrom(s => s.PolicyStartDate.DateTime))
                .ForMember(d => d.PolicyEndingDate, o => o.MapFrom(s => s.PolicyEndDate.DateTime))
                .IgnoreAllVirtual()
                .IgnoreUnmappedProperties();


            Mapper.CreateMap<WsClient, AddressDto>()
                .ForMember(d => d.PostalCode, o => o.MapFrom(s => s.IsLegalPerson ? s.LegalPerson.Address.PostalCode : s.NaturalPerson.Address.PostalCode))
                .ForMember(d => d.City, o => o.MapFrom(s => s.IsLegalPerson ? s.LegalPerson.Address.City : s.NaturalPerson.Address.City))
                .ForMember(d => d.StreetName, o => o.MapFrom(s => s.IsLegalPerson ? s.LegalPerson.Address.StreetName : s.NaturalPerson.Address.StreetName))
                .ForMember(d => d.StreetNumber, o => o.MapFrom(s => s.IsLegalPerson ? s.LegalPerson.Address.StreetNumber : s.NaturalPerson.Address.StreetNumber))
                .IgnoreAllVirtual()
                .IgnoreUnmappedProperties();

            Mapper.CreateMap<WsClient, MailingAddressDto>()
                .ForMember(d => d.PostalCode, o => o.MapFrom(s => s.IsLegalPerson ? s.LegalPerson.MailingAddress.PostalCode : s.NaturalPerson.MailingAddress.PostalCode))
                .ForMember(d => d.City, o => o.MapFrom(s => s.IsLegalPerson ? s.LegalPerson.MailingAddress.City : s.NaturalPerson.MailingAddress.City))
                .ForMember(d => d.StreetName, o => o.MapFrom(s => s.IsLegalPerson ? s.LegalPerson.MailingAddress.StreetName : s.NaturalPerson.MailingAddress.StreetName))
                .ForMember(d => d.StreetNumber, o => o.MapFrom(s => s.IsLegalPerson ? s.LegalPerson.MailingAddress.StreetNumber : s.NaturalPerson.MailingAddress.StreetNumber))
                .IgnoreAllVirtual()
                .IgnoreUnmappedProperties();

            Mapper.CreateMap<WsClient, Person>()
                .ForMember(d => d.Title, o => o.MapFrom(s => s.NaturalPerson.Title))
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.NaturalPerson.FirstName))
                .ForMember(d => d.LastName, o => o.MapFrom(s => s.NaturalPerson.LastName))
                .ForMember(d => d.MiddleName, o => o.MapFrom(s => s.NaturalPerson.MiddleName))
                .ForMember(d => d.BirthDate, o => o.MapFrom(s => new DateTimeOffset(s.NaturalPerson.BirthDate, TimeZoneInfo.Local.GetUtcOffset(s.NaturalPerson.BirthDate))))
                .ForMember(d => d.BirthPlace, o => o.MapFrom(s => s.NaturalPerson.BirthPlace))
                .ForMember(d => d.MotherFirstName, o => o.MapFrom(s => s.NaturalPerson.MotherFirstName))
                .ForMember(d => d.MotherLastName, o => o.MapFrom(s => s.NaturalPerson.MotherLastName))
                .ForMember(d => d.MotherMiddleName, o => o.MapFrom(s => s.NaturalPerson.MotherMiddleName))
                .ForMember(d => d.Gender, o => o.MapFrom(s => s.NaturalPerson.Gender))
                .ForMember(d => d.IdentityCardNumber, o => o.MapFrom(s => s.NaturalPerson.IdentityCardNumber))
                .IgnoreAllVirtual()
                .IgnoreUnmappedProperties();

            Mapper.CreateMap<WsClient, LegalPerson>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.LegalPerson.Name))
                .ForMember(d => d.TaxNumber, o => o.MapFrom(s => s.LegalPerson.TaxNumber))
                .IgnoreAllVirtual()
                .IgnoreUnmappedProperties();

            Mapper.CreateMap<WsClient, Client>()
               .ForMember(d => d.ClientCodeFromBroker, o => o.MapFrom(s => s.ClientCodeFromBroker))
               .ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
               .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.PhoneNumber))
               .ForMember(d => d.IsLegalPerson, o => o.MapFrom(s => s.IsLegalPerson))
               .IgnoreAllVirtual()
               .IgnoreUnmappedProperties();


            Mapper.CreateMap<WsVehicle, Vehicle>()
               .ForMember(d => d.PalateNumber, o => o.MapFrom(s => s.PalateNumber))
               .ForMember(d => d.VIN, o => o.MapFrom(s => s.VIN))
               .ForMember(d => d.RegistrationCertificateNumber, o => o.MapFrom(s => s.RegistrationCertificateNumber))
               .ForMember(d => d.Make, o => o.MapFrom(s => s.Make))
               .ForMember(d => d.Model, o => o.MapFrom(s => s.Model))
               .ForMember(d => d.Type, o => o.MapFrom(s => s.Type))
               .ForMember(d => d.Usage, o => o.MapFrom(s => s.Usage))
               .ForMember(d => d.Color, o => o.MapFrom(s => s.Color))
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

        public static IMappingExpression<TSource, TDest> IgnoreAll<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
        {
            expression.ForAllMembers(opt => opt.Ignore());
            return expression;
        }
    }
}