using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.Domain.Models.Auth;

namespace UBAInterviewPrepAPI.Domain.Models.InvestmentModels
{
    [Table("Investments")]
    public class Investment
    {
        [Key]
        public Guid Id { get; set; }
        //belongs to what User
        public Guid UserId { get; set; } //owner Id
        [ForeignKey("UserId")]
        public User Owner { get; set; } //investment owner
        //Portfolio ID = what stock or product or company are we investing into
        public Guid PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
        public decimal Principal { get; set; }
        public double InterestRate { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateCreated { get; set; }

        public decimal CummulativeInterestEarned { get; set; }
        public decimal CummulativeBalance { get; set; } //interest this month is = 20% of last months' cummulative balance
        //cummulative balance this month = interest earned + lastmonth cummulative balance...

    }


}
