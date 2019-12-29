using System.Collections.Generic;
using Arcana.Enums;
using Arcana.Enums.DeliveryMechanism;

namespace Arcana.Spells
{
    /// <summary>
    ///     Class representing a single delivery mechanism component of a crafted spell.
    ///     The delivery mechanism can have one or more cascade mechanisms (self referential in a sense)
    ///     as well as effects. The topmost delivery mechanism is used to determine the cost of the spell being cast.
    /// </summary>
    public class DeliveryMechanism
    {
        /// <summary>
        ///     The type of delivery mechanism, hard coded behavior that this mechanism adheres to.
        /// </summary>
        public Style MechanismType { get; set; }

        /// <summary>
        ///     Whether the projectile obeys gravity
        /// </summary>
        public Gravity Gravity { get; set; }

        /// <summary>
        ///     Whether or not the projectile collides with solid tiles.
        /// </summary>
        public Corporeal TileCorporeal{ get; set; }

        /// <summary>
        ///     Whether or not the projectile collides with its target.
        /// </summary>
        public Corporeal TargetCorporeal { get; set; }

        /// <summary>
        ///     A list of zero or more mechanisms that this mechanism subsequently triggers when it resolves on its target.
        /// </summary>
        public List<DeliveryMechanism> CascadeMechanisms { get; set; }

        /// <summary>
        ///     A list of zero or more arcane effects that this mechanism enacts on the target when it resolves (collides) with its target.
        /// </summary>
        public List<ArcaneEffect> Effects { get; set; }

        /// <summary>
        ///     What is the spell allowed to hit? Determines what kind of target the spell will resolve on and what it will pass through.
        /// </summary>
        public Target Target { get; set; }

        /// <summary>
        ///     What is the seeking behavior of the projectile, if applicable? Can be "None".
        /// </summary>
        public Seeking Seeking { get; set; }

        /// <summary>
        ///     How many of this delivery mechanism fire when used. Defaults to 1. Only applies to rays and projectiles.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        ///     How many times this mechanism fires in a single cast (used to do machine gun/burst type spells)
        /// </summary>
        public int Repeat { get; set; }

        /// <summary>
        ///     How many ticks to delay each triggered repetition of the mechanism.
        /// </summary>
        public int RepeatDelay { get; set; }

        /// <summary>
        ///     How many degrees of variance from a controlled vector the delivery mechanism (projectile or ray) should have. Defaults to 0.
        /// </summary>
        public float Spread { get; set; }

        /// <summary>
        ///     How quickly the projectile travels, in pixels per update tick.
        /// </summary>
        public float Velocity { get; set; }

        /// <summary>
        ///     How scaled-up the delivery mechanism "entity" is, determining its collision area
        ///     This is a size, in pixels, to make it a little more straightforward for players to tune the size of specific projectile styles.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        ///     How long (in ticks) the player must charge the conduit in order to fire the mechanism.
        ///     This can only be applied to the root mechanism, and is nonsensical for cascade mechanisms.
        /// </summary>
        public int ChargeTime { get; set; }

        /// <summary>
        ///     How long (in ticks) the resolved mechanism waits before releasing its cascade mechanism(s)
        /// </summary>
        public int CascadeDelay { get; set; }

        /// <summary>
        ///     How long (in ticks) the resolved mechanism waits before activating its effect on the target.
        /// </summary>
        public int EffectDelay { get; set; }

        /// <summary>
        ///     How long (in ticks) the conduit must rest before it can be used or charged next.
        ///     This can only be applied to the root mechanism and is nonsensical for cascade mechanisms.
        /// </summary>
        public int Cooldown { get; set; }

        /// <summary>
        ///     Flag representing whether this is a root delivery mechanism or a cascade mechanism.
        /// </summary>
        public bool IsRootMechanism { get; set; }
    }
}