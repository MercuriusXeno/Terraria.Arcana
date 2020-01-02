using System;
using Arcana.Reference;
using Terraria.ModLoader.IO;

namespace Arcana.Spells.DeliveryMechanisms
{
    public class Ray : DeliveryMechanismType
    {
        public Ray() : base(Constants.DeliveryMechanisms.RAY)
        {
        }

        public static readonly Func<TagCompound, Ray> DESERIALIZER = Load<Ray>;


        public override void HandleDrawing(ArcaneEvent arcaneEvent)
        {
        }

        public override void Process(ArcaneEvent arcaneEvent)
        {
        }
    }
}