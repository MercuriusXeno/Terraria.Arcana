using System;
using Terraria.ModLoader.IO;
using Arcana.Reference;

namespace Arcana.Spells.Elements
{
    public class Fire : Element
    {
        public Fire() : base(Constants.Elements.FIRE)
        {
        }

        public static readonly Func<TagCompound, Fire> DESERIALIZER = Load<Fire>;
    }
}