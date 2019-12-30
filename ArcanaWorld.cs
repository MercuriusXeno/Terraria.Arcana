using System.Collections.Generic;
using Arcana.Spells;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arcana
{
    public class ArcanaWorld : ModWorld
    {

        /// <summary>
        ///     A list of arcane events "alive" in the world in need of processing. When the effects of an event fully resolve (or expire otherwise) they're removed from the list.
        /// </summary>
        private List<ArcaneEvent> _arcaneEvents;

        public override void Initialize()
        {
            _arcaneEvents = new List<ArcaneEvent>();
        }

        public override void PostDrawTiles()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                Update();
            }
        }

        public override void PostUpdate()
        {
            if (Main.netMode == NetmodeID.SinglePlayer || Main.dedServ)
            {
                Update();
            }
        }

        private void Update()
        {
            foreach (var arcaneEvent in _arcaneEvents)
            {
                arcaneEvent.Update();
            }

            _arcaneEvents.RemoveAll(a => a.IsResolved);
        }

        public void AddArcaneEvent(ArcaneEvent arcaneEvent)
        {
            _arcaneEvents.Add(arcaneEvent);
        }
    }
}