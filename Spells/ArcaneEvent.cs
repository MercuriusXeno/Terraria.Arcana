using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcana.Enums.DeliveryMechanism;
using Arcana.Spells.Elements;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config.UI;

namespace Arcana.Spells
{
    /// <summary>
    ///     Class representing the "utility" or event that occurs when a delivery mechanism is traveling, colliding and/or resolving its effect.
    ///     This is "the magic" that is occurring, which contains the template definitions of the things that are happening/mechanisms/effects.
    /// </summary>
    public class ArcaneEvent
    {
        public ArcaneEvent(DeliveryMechanism mechanism, Vector2 origin, Vector2 velocity)
        {
            Mechanism = mechanism;
            TicksElapsed = 0;
            LastTicksElapsed = 0;
            Origin = origin;
            Velocity = velocity;
            ResolvingTicks = 0;
            CollisionsRemaining = mechanism.CollisionLimit;
        }

        /// <summary>
        ///     The number of ticks passed since the delivery mechanism was released from either the conduit or its parent mechanism.
        /// </summary>
        public int TicksElapsed { get; set; }

        /// <summary>
        ///     Helper expression to get the position of the virtual projectile based on the velocity, the origin and the time elapsed.
        /// </summary>
        public Vector2 Position => Origin + (Velocity * TicksElapsed);


        /// <summary>
        ///     Helper expression to get the distance traveled by the virtual projectile.
        /// </summary>
        public float Distance => Vector2.Distance(Origin, Position);

        /// <summary>
        ///     Used by client sync coding to determine what portion of drawing needs to occur during draw events, and processing.
        /// </summary>
        public int LastTicksElapsed { get; set; }

        /// <summary>
        ///     Helper expression to get the position of the virtual projectile based on the velocity, the origin and the last processed time elapsed.
        /// </summary>
        public Vector2 LastPosition => Origin + (Velocity * LastTicksElapsed);

        // Not sure if I need this one - maybe not necessary
        // public float LastDistance => Vector2.Distance(Origin, LastPosition);

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
        ///     The number of collisions the delivery mechanism has before it needs to expire.
        /// </summary>
        public int CollisionsRemaining { get; set; }

        /// <summary>
        ///     Once the event begins resolving, this expression bodied property returns true.
        /// </summary>
        public bool IsResolving => ResolvingTicks > 0;

        /// <summary>
        ///     Once the event no longer has resolves remaining, or needs to die a natural death, this is what tells the world to cull the event from processing.
        /// </summary>
        public bool IsResolved => CollisionsRemaining == 0 || TicksElapsed >= Mechanism.Lifespan;

        /// <summary>
        ///     Called by the world processing PostUpdate to resolve arcane events that are alive. This is what processes the delivery mechanism and
        ///     draws/resolves effects, tracks state and, importantly, syncs to clients if applicable.
        /// </summary>
        public void Update()
        {
            TicksElapsed++;
            HandleDrawing();

            HandleCollision();

            LastTicksElapsed = TicksElapsed;
        }

        private void HandleCollision()
        {
            
        }

        private void HandleDrawing()
        {
            // figure out based on velocity and time what portion of the event to draw
            bool isDoneDrawing = false;
            Vector2 lerpVector = LastPosition;
            float lerpAmount = 0.0F;
            while (!isDoneDrawing)
            {
                lerpAmount += 0.1F;
                float currentDrawDistance = Vector2.Distance(Origin, lerpVector);
                if (currentDrawDistance >= Distance)
                {
                    isDoneDrawing = true;
                }
                lerpVector = Vector2.Lerp(LastPosition, Position, lerpAmount);
                Dust dust = CreateDustForMechanism(lerpVector);
            }
        }

        private Dust CreateDustForMechanism(Vector2 position)
        {
            int dust = GetDustFromDominantElement();
            Dust result = Dust.NewDustPerfect(position, dust, Velocity, 0, default(Color), Mechanism.Scale);
            result.noGravity = Mechanism.Gravity != Gravity.Gravity;
            result.alpha = 50;
            return result;
        }

        private int GetDustFromDominantElement()
        {
            return ArcanaMod.Instance.DustType(GetDustNameFromDominantElement());
        }

        private string GetDustNameFromDominantElement()
        {
            IElement dominantElement = null;
            float dominantFactor = float.MinValue;
            
            for (int i = 0; i < Mechanism.Effects.Count; i++)
            {
                foreach (KeyValuePair<IElement, float> element in Mechanism.Effects[i].Elements)
                {
                    if (element.Value > dominantFactor)
                    {
                        dominantFactor = element.Value;
                        dominantElement = element.Key;
                    }
                }
            }

            
            return dominantElement?.GetDustName();
        }
    }
}
