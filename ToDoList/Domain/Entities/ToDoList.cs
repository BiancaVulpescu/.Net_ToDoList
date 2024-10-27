namespace Domain.Entities
{
    public class ToDoList
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime DueDate { get; set; }

    }
}
