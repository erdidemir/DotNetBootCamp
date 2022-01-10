using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class ToDoItemDto
    {
        [StringLength(10)]
        public string Name { get; set; }    
            

        public bool? IsComplete { get; set; }

    }
}
