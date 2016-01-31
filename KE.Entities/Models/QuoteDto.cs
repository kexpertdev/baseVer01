using KE.Entities.Emuns;
using KE.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.Models
{
    public class QuoteDto
    {
        public long ID { get; set; }
        public Guid Guid { get; set; }


        [Required]
        public int Broker_ID { get; set; }
        [Required, EnumDataType(typeof(Products))]
        public Products Product_ID { get; set; }
        [Required, EnumDataType(typeof(PolicyTypes))]
        public PolicyTypes PolicyType_ID { get; set; }
        [Required]
        public DateTimeOffset PolicyStartDate { get; set; }
        [Required]
        public int PolicyNrOfMonthsValid { get; set; }
        [Required]
        public PolicyPaymentMethods PolicyPaymentMethod_ID { get; set; }
        [Required, EnumDataType(typeof(VehicleTypes))]
        public VehicleTypes VehicleType_ID { get; set; }
        [Required, EnumDataType(typeof(VehicleUsages))]
        public VehicleUsages VehicleUsage_ID { get; set; }
        [Required, EnumDataType(typeof(LegalEntity))]
        public LegalEntity IsLegalPerson { get; set; }
        [StringLength(6)]
        public string PostalCode { get; set; }
        [StringLength(50)]
        public InsuranceCompanies InsuranceCompany { get; set; }
        [StringLength(50)]
        public string InsurancePolicyNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset InsuranceStartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset InsuranceEndDate { get; set; }


        public string RequestUrl { get; set; }

        
        public decimal Premium { get; set; }
        public DateTimeOffset PolicyEndDate { get; set; }


        [Display(Name = "Created at"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset Created { get; set; }
    }
}
