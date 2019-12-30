using System.Collections.Generic;
using Arcana.Spells;
using Terraria.ModLoader;

namespace Arcana
{
	public class Arcana : Mod
    {
        /// <summary>
        ///     Captured instance of the mod for reference in places that need it.
        /// </summary>
        public static Arcana instance;

        public Arcana()
        {
            instance = this;
        }
    }
}