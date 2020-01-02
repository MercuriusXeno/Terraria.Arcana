using System;
using Terraria.ModLoader.IO;
using Arcana.Reference;

namespace Arcana.Spells.Elements
{
    public class Death : Element
    {
        public Death() : base(Constants.Elements.DEATH)
        {
        }

        public static readonly Func<TagCompound, Death> DESERIALIZER = Load<Death>;
    }
}