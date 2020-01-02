using System;
using Terraria.ModLoader.IO;
using Arcana.Reference;

namespace Arcana.Spells.Elements
{
    public class Water : Element
    {
        public Water() : base(Constants.Elements.WATER)
        {
        }

        public static readonly Func<TagCompound, Water> DESERIALIZER = Load<Water>;
    }
}