using System;
using Terraria.ModLoader.IO;
using Arcana.Reference;

namespace Arcana.Spells.Elements
{
    public class Lightning : Element
    {
        public Lightning() : base(Constants.Elements.LIGHTNING)
        {
        }

        public static readonly Func<TagCompound, Lightning> DESERIALIZER = Load<Lightning>;
    }
}