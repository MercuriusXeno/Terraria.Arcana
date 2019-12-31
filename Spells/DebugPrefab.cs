using System.Collections.Generic;
using Arcana.Enums.DeliveryMechanism;
using Arcana.Reference;
using Arcana.Spells.Elements;

namespace Arcana.Spells
{
    public class DebugPrefab
    {
        public static ArcaneEffect BasicFireDamage = new ArcaneEffect()
        {
            BaseCosts = new List<PrimalCost>(),
            Costs = new List<PrimalCost>(),
            Duration = 0,
            Elements = new Dictionary<IElement, float>()
            {
                [ElementLoader.Instance.GetGeneric<Fire>()] = 1.0F
            },
            CorruptRatio = 0F,
            Effect = Effect.Harm,
            Power = 5,
            PrimalRatio = 0F
        };
    }
}