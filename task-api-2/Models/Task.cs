using System.ComponentModel.DataAnnotations;


namespace task_api_2.Models
{
    public class Task
    {

        public int TaskId { get; set; }
        // task id (ID)
        [Required]
        public string Title { get; set; }
        //title (string)
        [Required]
        public bool Completed { get; set; }
        //completed (boolean)
    }
}