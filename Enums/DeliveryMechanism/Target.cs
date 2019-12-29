namespace Arcana.Enums.DeliveryMechanism
{
    public enum Target
    {
        None = 0, // error state?
        Self = 1,
        Ally = 2, // includes self
        Enemy = 3,
        Location = 4
    }
}