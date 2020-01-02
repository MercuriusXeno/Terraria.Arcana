using System;
using Terraria.ModLoader.IO;
using Arcana.Reference;

namespace Arcana.Spells.Elements
{
    public class Neutral : Element
    {
        public Neutral() : base(Constants.Elements.NEUTRAL)
        {
        }

        public static readonly Func<TagCompound, Neutral> DESERIALIZER = Load<Neutral>;
    }
}