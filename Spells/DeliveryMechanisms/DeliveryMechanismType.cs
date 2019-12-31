namespace Arcana.Spells.DeliveryMechanisms
{
    public abstract class DeliveryMechanismType : IDeliveryMechanismType
    {
        protected DeliveryMechanismType(string name)
        {
            UnlocalizedName = name;
        }


        public abstract void HandleDrawingDust(ArcaneEvent arcaneEvent);

        public abstract void Process(ArcaneEvent arcaneEvent);


        public string UnlocalizedName { get; }
    }
}