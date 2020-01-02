using System;
using Terraria.ModLoader.IO;
using Arcana.Reference;

namespace Arcana.Spells.Elements
{
    public class Light : Element
    {
        public Light() : base(Constants.Elements.LIGHT)
        {
        }

        public static readonly Func<TagCompound, Light> DESERIALIZER = Load<Light>;
    }
}