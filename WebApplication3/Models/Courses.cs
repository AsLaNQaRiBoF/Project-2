using System.Data;

namespace WebApplication3.Models
{
    public class Courses
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public int Time { get; set; }   
        public int TeacherId { get; set; }
        public Teacher? teacher { get; set; }    
    }
}
