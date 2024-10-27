﻿namespace Application.DTOs
{
    public class ToDoListDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime DueDate { get; set; }
    }
}
