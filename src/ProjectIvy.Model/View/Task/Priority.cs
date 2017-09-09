﻿using DatabaseModel = ProjectIvy.Model.Database.Main;

namespace ProjectIvy.Model.View.Task
{
    public class Priority
    {
        public Priority(DatabaseModel.Org.TaskPriority x)
        {
            Name = x.Name;
            Id = x.ValueId;
        }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}