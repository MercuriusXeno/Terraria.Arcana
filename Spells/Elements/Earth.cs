using System;
using Terraria.ModLoader.IO;
using Arcana.Reference;

namespace Arcana.Spells.Elements
{
    public class Earth : Element
    {
        public Earth() : base(Constants.Elements.EARTH)
        {
        }

        public static readonly Func<TagCompound, Earth> DESERIALIZER = Load<Earth>;
    }
}