using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common
{
    public class Quotation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("RefCode")]
        [Required]
        public Currency Coin { get; set; }
        [Required]
        public double Value { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
