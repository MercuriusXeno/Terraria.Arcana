using System;
using Terraria.ModLoader.IO;
using Arcana.Reference;

namespace Arcana.Spells.Elements
{
    public class Shadow : Element
    {
        public Shadow() : base(Constants.Elements.SHADOW)
        {
        }

        public static readonly Func<TagCompound, Shadow> DESERIALIZER = Load<Shadow>;
    }
}