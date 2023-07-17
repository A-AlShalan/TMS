﻿namespace TMS.Dtos
{
	public class TaskDto
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public int tasksListId { get; set; }
        public DateTime DueDate { get; set; }
    }
}

