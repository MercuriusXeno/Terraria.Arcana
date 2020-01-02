using System.Collections.Generic;
using Arcana.Spells;
using Arcana.Spells.DeliveryMechanisms;
using Arcana.Spells.Elements;
using Terraria.ModLoader;

namespace Arcana
{
	public class ArcanaMod : Mod
    {
        public override void Load()
        {
            base.Load();
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