using System;
using Terraria.ModLoader.IO;
using Arcana.Reference;

namespace Arcana.Spells.Elements
{
    public class Temporal : Element
    {
        public Temporal() : base(Constants.Elements.TEMPORAL)
        {
        }

        public static readonly Func<TagCompound, Temporal> DESERIALIZER = Load<Temporal>;
    }
}