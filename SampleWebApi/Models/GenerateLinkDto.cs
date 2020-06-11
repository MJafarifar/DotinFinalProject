using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleWebApi.Models
{
    /// <summary>
    /// مدل مربوط به نمایش لینک کوتاه
    /// </summary>
    public class GenerateLinkDto
    {
       /// <summary>
       /// شناسه اتوماتیک
       /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// لینک
        /// </summary>
        [Required]
		public string URL { get; set; }

        /// <summary>
        /// لینک کوتاه
        /// </summary>
        [Required]
        public string ShortenedURL { get; set; }

        /// <summary>
        /// توکن لینک کوتاه
        /// </summary>
        [Required]
        public string Token { get; set; }
        /// <summary>
        /// تعداد کلیک ها بر روی لینک کوتاه
        /// </summary>
        [Required]
        public int Clicked { get; set; } = 0;
        /// <summary>
        /// تاریخ ایجاد
        /// </summary>
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}