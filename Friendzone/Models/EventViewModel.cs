using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Friendzone.Web.Models
{
    public class EventEditViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Required]
        public DateTime DateFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateTo { get; set; }

        public int CityId { get; set; }

        public List<int> CategoryIds { get; set; }
        //public List<Category> Categories { get; set; }
        
        [Required]
        public int OwnerId { get; set; }

        public string Description { get; set; }

        //public IFormFile formFile { get; set; }
    }
}
