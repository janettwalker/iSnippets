using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iSnippets.Models
{
    public class Snippet  
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Title { get; set;  }
         
        [StringLength(30, MinimumLength = 3)]
        public string Description { get; set;  }
     
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Language { get; set;  }
       
        [StringLength(400, MinimumLength = 3)]
        [Display(Name = "Code Snippet")]
        public string Code_Snippet { get; set;  }
    
    }
}