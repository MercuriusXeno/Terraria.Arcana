namespace Arcana.Spells.DeliveryMechanisms
{
    public interface IDeliveryMechanism
    {
        string Name { get; }
        void HandleDrawingDust(ArcaneEvent arcaneEvent);
        void Process(ArcaneEvent arcaneEvent);
    }
}