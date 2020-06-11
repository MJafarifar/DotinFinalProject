using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleWebApi.Models
{
    public class GenerateLinkEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string URL { get; set; }
        [Required]
        public string ShortenedURL { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public int Clicked { get; set; } = 0;
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}