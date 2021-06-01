using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UBAInterviewPrepAPI.Domain.Models.InvestmentModels
{
    [Table("MonthlyInvestmentQuotes")]
    public class MonthlyInvestmentQuote
    {
        [Key]
        public int Id { get; set; }
        //what Investment
        public Guid InvestmentId { get; set; }
        [ForeignKey("InvestmentId")]
        public Investment Investment { get; set; }
        public decimal Balance { get; set; }
        public decimal Interest { get; set; }
        public decimal CummulativeInterest { get; set; } //this is total interest earned since beginning of investment...
        public decimal CummulativeBalance { get; set; } // this is the total balance since beginning of investmtnet

    }
}
