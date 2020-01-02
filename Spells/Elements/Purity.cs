using System;
using Terraria.ModLoader.IO;
using Arcana.Reference;

namespace Arcana.Spells.Elements
{
    public class Purity : Element
    {
        public Purity() : base(Constants.Elements.PURITY)
        {
        }

        public static readonly Func<TagCompound, Purity> DESERIALIZER = Load<Purity>;
    }
}