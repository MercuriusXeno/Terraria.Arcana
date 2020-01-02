using System;
using Arcana.Reference;
using Terraria.ModLoader.IO;

namespace Arcana.Spells.Elements
{
    public class Air : Element
    {
        public Air() : base(Constants.Elements.AIR)
        {
        }

        public static readonly Func<TagCompound, Air> DESERIALIZER = Load<Air>;
    }
}