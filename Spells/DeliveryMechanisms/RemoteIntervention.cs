using Arcana.Reference;

namespace Arcana.Spells.DeliveryMechanisms
{
    public class RemoteIntervention : IDeliveryMechanism
    {
        public string Name => Constants.DeliveryMechanisms.RemoteIntervention;

        public void HandleDrawingDust(ArcaneEvent arcaneEvent)
        {
        }

        public void Process(ArcaneEvent arcaneEvent)
        {
        }
    }
}