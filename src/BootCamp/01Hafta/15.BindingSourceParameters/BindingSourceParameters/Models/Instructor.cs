using Microsoft.AspNetCore.Mvc;

namespace BindingSourceParameters.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        [FromQuery(Name = "Note")]
        public string NoteFromQueryString { get; set; }
    }
}
