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

        public static readonly Func<TagCompound, Element> DESERIALIZER = Load;

        public static Element Load(TagCompound tag)
        {
            return ElementLoader.Instance.GetGeneric(tag.GetString(Constants.NbtNames.Common.UNLOCALIZED_NAME));
        }
    }
}