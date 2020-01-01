using Arcana.Reference;

namespace Arcana.Spells.Elements
{
    public abstract class Element : IElement
    {
        protected Element(string name)
        {
            UnlocalizedName = name;
        }


        public virtual string GetDustName() => $"{UnlocalizedName}{Constants.DUST}";


        public string UnlocalizedName { get; }
    }
}