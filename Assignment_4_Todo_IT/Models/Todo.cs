using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_Todo_IT.Models
{
    public class Todo
    {
        private readonly int todoid;
        private string description;
        private bool done;
        private Person assignee;

        public Todo(int todoid, string description)
        {
            this.todoid = todoid;
            this.description = description;
            this.done = false;
        }

        public int Todoid
        {
            get
            {
                return this.todoid;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public bool Done
        {
            get
            {
                return this.done;
            }
            set
            {
                this.done = value;
            }
        }

        public Person Assignee
        {
            get
            {
                return this.assignee;
            }
            set
            {
                this.assignee = value;
            }
        }
    }
}
