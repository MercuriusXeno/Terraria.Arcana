using System.Collections.Generic;
using Arcana.Enums.DeliveryMechanism;
using Arcana.Reference;
using Arcana.Spells.DeliveryMechanisms;
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

        public static DeliveryMechanism BasicFireProjectile = new DeliveryMechanism()
        {
            Corporeal = Corporeal.Corporeal,
            CascadeDelay = 2,
            CascadeMechanisms = new List<DeliveryMechanism>(),
            Effects = new List<ArcaneEffect>()
            {
                BasicFireDamage
            },
            CollisionBehavior = CollisionBehavior.None,
            Target = Target.Enemy,
            Gravity = Gravity.NoGravity,
            Seeking = Seeking.None,
            ChargeTime = 0,
            CollisionLimit = 1,
            Cooldown = 5,
            Count = 1,
            EffectDelay = 0,
            IsRootMechanism = true,
            MechanismType = DeliveryMechanismTypeLoader.Instance.GetGeneric<Projectile>(),
            Repeat = 0,
            RepeatDelay = 0,
            Scale = 3.0F,
            Speed = 30.0F,
            Spread = 15.0F,
            DominantDustType = 6,
            Lifespan = 60
        };
    }
}