using System;
using Terraria.ModLoader.IO;
using Arcana.Reference;

namespace Arcana.Spells.Elements
{
    public class Life : Element
    {
        public Life() : base(Constants.Elements.LIFE)
        {
        }

        public static readonly Func<TagCompound, Life> DESERIALIZER = Load<Life>;
    }
}