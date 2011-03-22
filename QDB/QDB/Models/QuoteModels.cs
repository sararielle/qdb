using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QDB.Models
{
    public class QuoteModel
    {
        [Required]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Quote")]
        public string Quote { get; set; }

        [Required]
        [Display(Name = "Date Submitted")]
        public DateTime DateSubmitted { get; set; }
    }
}