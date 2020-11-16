namespace Entities
{
    public class Role
    {
        public Role(string name, string description)
        {
            Name = name;
            Description = description;
        }

        private Role() { }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}