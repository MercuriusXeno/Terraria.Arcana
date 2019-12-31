using System.Collections.Generic;
using Arcana.Enums.DeliveryMechanism;
using Arcana.Spells.Elements;

namespace Arcana.Spells
{
    /// <summary>
    ///     Class representing what happens when a delivery mechanism "resolves", carrying out its effect (this) on its target.
    ///     Effects are what actually happens to the target rather than how they get there.
    /// </summary>
    public class ArcaneEffect
    {
        public ArcaneEffect()
        {
            Elements = new Dictionary<IElement, float>();
            BaseCosts = new List<PrimalCost>();
            Costs = new List<PrimalCost>();
        }

        /// <summary>
        ///     The magnitude of the effect, whatever it is. If this is a temporal spell (has a duration) then the Power is divided equally into each tick.
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        ///     If the effect is temporal, it has a duration. A duration of 0 means instant effect only. Some spells don't make sense to be instant (like buffs)
        ///     and are Temporal by default. This is how long it lasts, in ticks.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        ///     The ratio of the magic effect being cast using Arcane instead of Primal. Higher Primal means lower Arcane. Ranges from 0 to 1 with 1 being 100% primal.
        ///     Note that some spells can include an arcane cost anyway - this won't negate flat arcane costs.
        /// </summary>
        public float PrimalRatio { get; set; }

        /// <summary>
        ///     The percentage of the spell effect is applied to the caster when it resolves. This reduces the cost of the magic significantly in exchange for self-harm.
        /// </summary>
        public float CorruptRatio { get; set; }

        /// <summary>
        ///     Whether the effect is an over time effect. This is an expression bodied member that simply returns whether the duration is greater than 0.
        /// </summary>
        public bool IsTemporal => Duration > 0;

        /// <summary>
        ///     The most important part, this is what the arcane effect does when it resolves. This also helps determines its cost as a function of its elements.
        /// </summary>
        public Effect Effect { get; set; }

        /// <summary>
        ///     The elements the effect contains as a dictionary of their ratio to the overall effect. This is used to determine scaling, the nature of the effect itself, and cost.
        /// </summary>
        public Dictionary<IElement, float> Elements { get; set; }

        /// <summary>
        ///     The base cost of casting the effect as a function of its elements, its type, before its modifiers are applied.
        /// </summary>
        public List<PrimalCost> BaseCosts { get; set; }

        /// <summary>
        ///     The cost of the effect after its modifiers are applied.
        /// </summary>
        public List<PrimalCost> Costs { get; set; }
    }
}