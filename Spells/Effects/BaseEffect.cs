using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcana.Enums;
using Arcana.Enums.DeliveryMechanism;

namespace Arcana.Spells.Effects
{
    /// <summary>
    ///     Class representing a type of arcane effect, these are what make up the list of options you can select when crafting custom magic.
    /// </summary>
    class BaseEffect
    {
        public BaseEffect()
        {
            ElementalTypes = new List<ElementalType>();
            BaseCosts = new List<PrimalCost>();
            Costs = new List<PrimalCost>();
        }

        /// <summary>
        ///     Whether or not the effect should draw more from primals or mana, respectively.
        ///     Leads to a logarithmic function, defaults to 0.5
        /// </summary>
        public float PrimalRatio { get; set; }

        /// <summary>
        ///     Whether the effect is mirrored onto the caster, which subsequently reduces the mana cost.
        ///     Leads to a proportional/linear function, defaults to 0
        /// </summary>
        public float CorruptedRatio { get; set; }

        /// <summary>
        ///     Whether or not the effect is *Temporal*, creating temporal spells means they have a duration, and their power is divided over the duration rather than immediate.
        ///     Defaults to false for damage or healing, but true for buffs and debuffs.
        /// </summary>
        public bool IsTemporal { get; set; }

        /// <summary>
        ///     Whether or not the mana cost of the effect is being exchanged for life costs instead. The conversion is a direct proportion.
        ///     Ranges from 0 to 1, defaults to 0.
        /// </summary>
        public float BloodRatio { get; set; }

        /// <summary>
        ///     The proportion of primals that are converted to Arcane primal cost, to a minimum of 1 for each non-arcane primal.
        ///     Costs scale directly - each point of reduction in a given primal increases the cost of arcane by a single point.
        /// </summary>
        public float SimplicityRatio { get; set; }

        /// <summary>
        ///     What type of effect this is.
        /// </summary>
        public Effect ArcaneEffectType { get; set; }

        /// <summary>
        ///     A list of the elemental types of the effect, used to determine the primal affinity of the magic. Not to be confused with primal costs.
        /// </summary>
        public List<ElementalType> ElementalTypes { get; set; }

        /// <summary>
        ///     The BASE primal and mana costs of the effect, used to determine the casting requirements when the spell is cast.
        ///     For the sake of avoiding a lot of recalculation real-time, when values modifying the base costs of an effect are changed, they're persisted.
        ///     (See Costs)
        /// </summary>
        public List<PrimalCost> BaseCosts { get; set; }

        /// <summary>
        ///     The "True" costs of the spell effect being cast, after all coefficients/modifiers are taken into consideration.
        /// </summary>
        public List<PrimalCost> Costs { get; set; }
    }
}
