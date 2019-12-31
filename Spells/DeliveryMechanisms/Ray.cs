using Arcana.Reference;

namespace Arcana.Spells.DeliveryMechanisms
{
    public class Ray : IDeliveryMechanism
    {
        public string Name => Constants.DeliveryMechanisms.Ray;

        public void HandleDrawingDust(ArcaneEvent arcaneEvent)
        {
        }

        public void Process(ArcaneEvent arcaneEvent)
        {
        }
    }
}