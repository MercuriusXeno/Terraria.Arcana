using Arcana.Enums.DeliveryMechanism;
using Arcana.Reference;
using Microsoft.Xna.Framework;
using Terraria;

namespace Arcana.Spells.DeliveryMechanisms
{
    public class Projectile : DeliveryMechanismType
    {
        public Projectile() : base(Constants.DeliveryMechanisms.PROJECTILE)
        {
        }


        public override void HandleDrawing(ArcaneEvent arcaneEvent)
        {
            int dustId = arcaneEvent.GetDustFromDominantElement();

            Vector2 lerpVector = arcaneEvent.Position;
            float lerpAmount = 0.0F;
            while (lerpAmount < 1.0F)
            {
                lerpAmount += 16F / arcaneEvent.Mechanism.Speed;
                lerpVector = Vector2.Lerp(arcaneEvent.LastPosition, arcaneEvent.Position, lerpAmount);
                Dust dust = Dust.NewDustPerfect(lerpVector, dustId, arcaneEvent.Velocity, 0, default(Color), arcaneEvent.Mechanism.Scale);
                dust.noGravity = arcaneEvent.Mechanism.Gravity != Gravity.Gravity;
            }
        }

        public override void Process(ArcaneEvent arcaneEvent)
        {
        }
    }
}