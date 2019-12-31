using System.Collections.Generic;
using Arcana.Spells;
using Terraria.ModLoader;

namespace Arcana
{
	public class ArcanaMod : Mod
    {
        public ArcanaMod()
        {
            Instance = this;
        }


        public override void Unload()
        {
            Instance = null;
        }


        /// <summary>The current loaded instance of <see cref="ArcanaMod"/>.</summary>
        public static ArcanaMod Instance { get; private set; }
    }
}