using Arcana.Reference;

namespace Arcana.Spells.DeliveryMechanisms
{
    public class Projectile : IDeliveryMechanism
    {
        public string Name => Constants.DeliveryMechanisms.Projectile;

        public void HandleDrawingDust(ArcaneEvent arcaneEvent)
        {
        }

        public void Process(ArcaneEvent arcaneEvent)
        {
        }
    }
}