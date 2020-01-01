using WebmilioCommons.Managers;

namespace Arcana.Spells.DeliveryMechanisms
{
    public interface IDeliveryMechanismType : IHasUnlocalizedName
    {
        void HandleDrawing(ArcaneEvent arcaneEvent);

        void Process(ArcaneEvent arcaneEvent);
    }
}