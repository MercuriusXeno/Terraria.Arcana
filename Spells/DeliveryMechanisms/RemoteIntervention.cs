using System;
using Arcana.Reference;
using Terraria.ModLoader.IO;

namespace Arcana.Spells.DeliveryMechanisms
{
    public class RemoteIntervention : DeliveryMechanismType
    {
        public RemoteIntervention() : base(Constants.DeliveryMechanisms.REMOTE_INTERVENTION)
        {
        }

        public static readonly Func<TagCompound, RemoteIntervention> DESERIALIZER = Load<RemoteIntervention>;


        public override void HandleDrawing(ArcaneEvent arcaneEvent)
        {
        }

        public override void Process(ArcaneEvent arcaneEvent)
        {
        }
    }
}