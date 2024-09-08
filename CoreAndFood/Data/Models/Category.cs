using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Data.Models
{
	public class Category
	{
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="Category Name not Empty")]
        [StringLength(20,ErrorMessage="Please only enter 4-20 characters",MinimumLength =4)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public bool Status { get; set; }
        public List<Food> Foods  { get; set; } //list olan yer ana yer olur yeni bir kategori içerisinde birden çok food olabilir
  
        
    
    }
}
