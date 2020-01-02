using System;
using Terraria.ModLoader.IO;
using Arcana.Reference;

namespace Arcana.Spells.Elements
{
    public class Corruption : Element
    {
        public Corruption() : base(Constants.Elements.CORRUPTION)
        {
        }

        public static readonly Func<TagCompound, Corruption> DESERIALIZER = Load<Corruption>;
    }
}