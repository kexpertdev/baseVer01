using KE.Entities.Emuns;
using KE.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.Models
{
    public class QuoteDto
    {
        public Guid Guid { get; set; }


        [Required]
        public int Broker_ID { get; set; }
        [Required, Display(Name = "Product"), EnumDataType(typeof(Products))]
        public Products Product_ID { get; set; }
        [Required, Display(Name = "Type"), EnumDataType(typeof(PolicyTypes))]
        public PolicyTypes PolicyType_ID { get; set; }
        [Required, Display(Name = "Start Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset PolicyStartDate { get; set; }
        [Display(Name = "End Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset PolicyEndDate { get; set; }
        [Display(Name = "Premium"), DisplayFormat(DataFormatString = "{0:####}")]
        public decimal Premium { get; set; }
        [Required]
        public int PolicyNrOfMonthsValid { get; set; }
        [Required, Display(Name = "Payment Method"),]
        public PolicyPaymentMethods PolicyPaymentMethod_ID { get; set; }
        [Required, Display(Name = "Vehicle Type"), EnumDataType(typeof(VehicleTypes))]
        public VehicleTypes VehicleType_ID { get; set; }
        [Required, Display(Name = "Vehicle Usage"), EnumDataType(typeof(VehicleUsages))]
        public VehicleUsages VehicleUsage_ID { get; set; }
        [Required, Display(Name = "Is Legal Person"), EnumDataType(typeof(LegalEntity))]
        public LegalEntity IsLegalPerson { get; set; }
        [Display(Name = "Postal Code"), StringLength(6)]
        public string PostalCode { get; set; }
        [StringLength(50)]
        public InsuranceCompanies InsuranceCompany { get; set; }
        [StringLength(50)]
        public string InsurancePolicyNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTimeOffset InsuranceStartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTimeOffset InsuranceEndDate { get; set; }


        public string RequestUrl { get; set; }


        [Display(Name = "Created at"), ReadOnly(true), Required, DisplayFormat(DataFormatString = "{0:yyyy/MM/dd H:mm}")]
        public DateTimeOffset Created { get; private set; }
    }
}
