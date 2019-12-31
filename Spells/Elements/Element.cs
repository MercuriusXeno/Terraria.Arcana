namespace Arcana.Spells.Elements
{
    public  abstract class Element : IElement
    {
        protected Element(string name)
        {
            Name = name;
        }


        public virtual string GetDustName() => $"{Name}Dust";


        public string Name { get; }
    }
}