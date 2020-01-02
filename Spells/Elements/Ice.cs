using System;
using Terraria.ModLoader.IO;
using Arcana.Reference;

namespace Arcana.Spells.Elements
{
    public class Ice : Element
    {
        public Ice() : base(Constants.Elements.ICE)
        {
        }

        public static readonly Func<TagCompound, Ice> DESERIALIZER = Load<Ice>;
    }
}