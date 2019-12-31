using WebmilioCommons.Managers;

namespace Arcana.Spells.DeliveryMechanisms
{
    public interface IDeliveryMechanismType : IHasUnlocalizedName
    {
        void HandleDrawingDust(ArcaneEvent arcaneEvent);

        void Process(ArcaneEvent arcaneEvent);
    }
}