using System;
using Arcana.Reference;
using Terraria.ModLoader.IO;

namespace Arcana.Spells.Elements
{
    public abstract class Element : IElement, TagSerializable
    {
        protected Element(string name)
        {
            UnlocalizedName = name;
        }


        public virtual string GetSmallDustName() => $"{UnlocalizedName}{Constants.Dust.DUST}{Constants.Dust.SMALL}";


        public string UnlocalizedName { get; }


        public TagCompound SerializeData()
        {
            return new TagCompound() { [Constants.NbtNames.Common.UNLOCALIZED_NAME] = UnlocalizedName };
        }

        public static readonly Func<TagCompound, Element> DESERIALIZER = Load<Element>;

        public static T Load<T>(TagCompound tag) where T : Element
        {
            return ElementLoader.Instance.GetGeneric<T>();
        }
    }
}