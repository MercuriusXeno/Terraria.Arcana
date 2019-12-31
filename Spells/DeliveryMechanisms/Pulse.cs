using Arcana.Reference;

namespace Arcana.Spells.DeliveryMechanisms
{
    public class Pulse : IDeliveryMechanism
    {
        public string Name => Constants.DeliveryMechanisms.Pulse;

        public void HandleDrawingDust(ArcaneEvent arcaneEvent)
        {
        }

        public void Process(ArcaneEvent arcaneEvent)
        {
        }
    }
}