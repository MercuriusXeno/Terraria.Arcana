using System;
using Terraria.ModLoader.IO;
using Arcana.Reference;

namespace Arcana.Spells.Elements
{
    public class Arcane : Element
    {
        public Arcane() : base(Constants.Elements.ARCANE)
        {
        }

        public static readonly Func<TagCompound, Arcane> DESERIALIZER = Load<Arcane>;
    }
}