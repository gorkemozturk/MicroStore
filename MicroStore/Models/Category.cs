using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicroStore.Models
{
    public class Category
    {
        [Required]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Parent Category")]
        public int? ParentId { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }

        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; }
    }
}
