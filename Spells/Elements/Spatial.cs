using System;
using Terraria.ModLoader.IO;
using Arcana.Reference;

namespace Arcana.Spells.Elements
{
    public class Spatial : Element
    {
        public Spatial() : base(Constants.Elements.SPATIAL)
        {
        }

        public static readonly Func<TagCompound, Spatial> DESERIALIZER = Load<Spatial>;
    }
}