using System.Xml.Linq;
using ErrorOr;

namespace TaskManagement.Models
{
    public class Task
    {


        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }

        private Task(
           Guid id,
           string name,
           string description
           )
        {
            Id = id;
            Name = name;
            Description = description;
           
        }

        public static ErrorOr<Task> Create(
            string name,
            string description,
            Guid? id = null
            )
        {
            List<Error> errors = new();

            return new Task(id ?? Guid.NewGuid(),
                name,
                description
            );
        }
    }
}
