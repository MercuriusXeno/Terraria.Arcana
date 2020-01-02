using System;
using Arcana.Reference;
using Terraria.ModLoader.IO;

namespace Arcana.Spells.DeliveryMechanisms
{
    public class Pulse : DeliveryMechanismType
    {
        public Pulse() : base(Constants.DeliveryMechanisms.PULSE)
        {
        }

        public static readonly Func<TagCompound, Pulse> DESERIALIZER = Load<Pulse>;


        public override void HandleDrawing(ArcaneEvent arcaneEvent)
        {
        }

        public override void Process(ArcaneEvent arcaneEvent)
        {
        }
    }
}