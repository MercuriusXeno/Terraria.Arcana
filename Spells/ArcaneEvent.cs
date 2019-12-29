using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcana.Enums.DeliveryMechanism;
using Microsoft.Xna.Framework;

namespace Arcana.Spells
{
    /// <summary>
    ///     Class representing the "utility" or event that occurs when a delivery mechanism is traveling, colliding and/or resolving its effect.
    ///     This is "the magic" that is occurring, which contains the template definitions of the things that are happening/mechanisms/effects.
    /// </summary>
    class ArcaneEvent
    {
        /// <summary>
        ///     The number of ticks passed since the delivery mechanism was released from either the conduit or its parent mechanism.
        /// </summary>
        public int TicksElapsed { get; set; }

        /// <summary>
        ///     The mechanism this event represents, contains all the template information the event needs to perform its resolver(s).
        /// </summary>
        public DeliveryMechanism Mechanism { get; set; }

        /// <summary>
        ///     The place the event originated, can be the conduit or the resolving site of the parent mechanism.
        /// </summary>
        public Vector2 Origin { get; set; }

        /// <summary>
        ///     How fast this mechanism is moving (and its bearing), not to be confused with its speed.
        /// </summary>
        public Vector2 Velocity { get; set; }

        /// <summary>
        ///     How many ticks the event has spent resolving, after it collides or resolves otherwise.
        /// </summary>
        public int ResolvingTicks { get; set; }

        /// <summary>
        ///     Once the event begins resolving, this expression bodied property returns true.
        /// </summary>
        public bool IsResolving => ResolvingTicks > 0;
    }
}
