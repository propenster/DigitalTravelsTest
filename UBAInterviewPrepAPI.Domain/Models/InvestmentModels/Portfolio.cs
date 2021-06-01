using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.Domain.Models.Auth;

namespace UBAInterviewPrepAPI.Domain.Models.InvestmentModels
{
    [Table("Portfolios")]
    public class Portfolio
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal MinimumInvestmentBalance { get; set; }
        public double InterestRate { get; set; } //Return on investment rate...
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public User Creator { get; set; }

    }
}
