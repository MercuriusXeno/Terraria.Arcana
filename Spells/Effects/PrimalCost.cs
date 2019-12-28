using System;
using Arcana.Enums;

namespace Arcana.Spells.Effects
{
    /// <summary>
    ///     Class representing the primal cost(s) of a spell effect or the cost of crafting (they're completely alike in every respect, it's just an element and a value)
    /// </summary>
    public class PrimalCost
    {
        /// <summary>
        ///     Which element is the primal cost? "None" can be used to track the non-primal cost of a spell when it is cast (mana!)
        /// </summary>
        public ElementalType Element { get; set; }

        /// <summary>
        ///     The cost in primals (or mana) of the effect or spell being crafted. Represented as a float for math purposes, but should be interacted with as a ceiling value
        ///     for the purposes of user interface. (FlatCost)
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        ///     The nearest greater-or-equal integral of the cost for the purposes of payment of a spell's cost casting or crafting.
        ///     Included for convenience.
        /// </summary>
        public int FlatCost => (int)Math.Ceiling(Cost);
    }
}