using System.ComponentModel.DataAnnotations;

namespace UnitTest_Mock.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desgination { get; set; }
    }
}
