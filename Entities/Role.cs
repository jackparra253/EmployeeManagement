namespace Entities
{
    public class Role
    {
        public Role(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        private Role() { }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}