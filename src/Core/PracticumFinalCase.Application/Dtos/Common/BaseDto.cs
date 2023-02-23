using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Dtos.Common
{
    public abstract class BaseDto
    {
        public int Id { get; set; }


        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }


        [MaxLength(500)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
    }
}
