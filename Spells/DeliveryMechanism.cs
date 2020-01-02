using System;
using System.Collections.Generic;
using System.Linq;
using Arcana.Enums.DeliveryMechanism;
using Arcana.Reference;
using Arcana.Spells.DeliveryMechanisms;
using Arcana.Spells.Elements;
using Terraria.ModLoader.IO;

namespace Arcana.Spells
{
    /// <summary>
    ///     Class representing a single delivery mechanism component of a crafted spell.
    ///     The delivery mechanism can have one or more cascade mechanisms (self referential in a sense)
    ///     as well as effects. The topmost delivery mechanism is used to determine the cost of the spell being cast.
    /// </summary>
    public class DeliveryMechanism : TagSerializable
    {
        public static readonly Func<TagCompound, DeliveryMechanism> DESERIALIZER = Load;

        public DeliveryMechanism()
        {
            CascadeMechanisms = new List<DeliveryMechanism>();
            Effects = new List<ArcaneEffect>();
        }

        public DeliveryMechanism(DeliveryMechanismType mechanismType, Gravity gravity, Corporeal corporeal, CollisionBehavior collisionBehavior, int collisionLimit,
            List<DeliveryMechanism> cascadeMechanisms, List<ArcaneEffect> effects, Target target, Seeking seeking, int count, int repeat, int repeatDelay,
            float spread, float speed, float scale, int chargeTime, int cascadeDelay, int effectDelay, int cooldown, bool isRootMechanism, int lifespan, int dominantDustType)
        {
            MechanismType = mechanismType;
            Gravity = gravity;
            Corporeal = corporeal;
            CollisionBehavior = collisionBehavior;
            CollisionLimit = collisionLimit;
            CascadeMechanisms = cascadeMechanisms;
            Effects = effects;
            Target = target;
            Seeking = seeking;
            Count = count;
            Repeat = repeat;
            RepeatDelay = repeatDelay;
            Spread = spread;
            Speed = speed;
            Scale = scale;
            ChargeTime = chargeTime;
            CascadeDelay = cascadeDelay;
            EffectDelay = effectDelay;
            Cooldown = cooldown;
            IsRootMechanism = isRootMechanism;
            Lifespan = lifespan;
            DominantDustType = dominantDustType;
        }

        private static DeliveryMechanism Load(TagCompound tag)
        {
            return new DeliveryMechanism(
                tag.Get<DeliveryMechanismType>(Constants.NbtNames.DeliveryMechanism.MECHANISM_TYPE),
                (Gravity)tag.GetInt(Constants.NbtNames.DeliveryMechanism.GRAVITY),
                (Corporeal)tag.GetInt(Constants.NbtNames.DeliveryMechanism.CORPOREAL),
                (CollisionBehavior)tag.GetInt(Constants.NbtNames.DeliveryMechanism.COLLISION_BEHAVIOR),
                tag.GetInt(Constants.NbtNames.DeliveryMechanism.COLLISION_LIMIT),
                tag.Get<List<DeliveryMechanism>>(Constants.NbtNames.DeliveryMechanism.CASCADE_MECHANISMS),
                tag.Get<List<ArcaneEffect>>(Constants.NbtNames.DeliveryMechanism.EFFECTS),
                (Target)tag.GetInt(Constants.NbtNames.DeliveryMechanism.TARGET),
                (Seeking)tag.GetInt(Constants.NbtNames.DeliveryMechanism.SEEKING),
                tag.GetInt(Constants.NbtNames.DeliveryMechanism.COUNT),
                tag.GetInt(Constants.NbtNames.DeliveryMechanism.REPEAT),
                tag.GetInt(Constants.NbtNames.DeliveryMechanism.REPEAT_DELAY),
                tag.GetFloat(Constants.NbtNames.DeliveryMechanism.SPREAD),
                tag.GetFloat(Constants.NbtNames.DeliveryMechanism.SPEED),
                tag.GetFloat(Constants.NbtNames.DeliveryMechanism.SCALE),
                tag.GetInt(Constants.NbtNames.DeliveryMechanism.CHARGE_TIME),
                tag.GetInt(Constants.NbtNames.DeliveryMechanism.CASCADE_DELAY),
                tag.GetInt(Constants.NbtNames.DeliveryMechanism.EFFECT_DELAY),
                tag.GetInt(Constants.NbtNames.DeliveryMechanism.COOLDOWN),
                tag.GetBool(Constants.NbtNames.DeliveryMechanism.IS_ROOT_MECHANISM),
                tag.GetInt(Constants.NbtNames.DeliveryMechanism.LIFESPAN),
                tag.GetInt(Constants.NbtNames.DeliveryMechanism.DOMINANT_DUST_TYPE)
            );
        }

        public TagCompound SerializeData()
        {
            TagCompound tag = new TagCompound()
            {
                [Constants.NbtNames.DeliveryMechanism.MECHANISM_TYPE] = MechanismType,
                [Constants.NbtNames.DeliveryMechanism.GRAVITY] = (int)Gravity,
                [Constants.NbtNames.DeliveryMechanism.CORPOREAL] = (int)Corporeal,
                [Constants.NbtNames.DeliveryMechanism.COLLISION_BEHAVIOR] = (int)CollisionBehavior,
                [Constants.NbtNames.DeliveryMechanism.COLLISION_LIMIT] = CollisionLimit,
                [Constants.NbtNames.DeliveryMechanism.CASCADE_MECHANISMS] = CascadeMechanisms,
                [Constants.NbtNames.DeliveryMechanism.EFFECTS] = Effects,
                [Constants.NbtNames.DeliveryMechanism.TARGET] = (int)Target,
                [Constants.NbtNames.DeliveryMechanism.SEEKING] = (int)Seeking,
                [Constants.NbtNames.DeliveryMechanism.COUNT] = Count,
                [Constants.NbtNames.DeliveryMechanism.REPEAT] = Repeat,
                [Constants.NbtNames.DeliveryMechanism.REPEAT_DELAY] = RepeatDelay,
                [Constants.NbtNames.DeliveryMechanism.SPREAD] = Spread,
                [Constants.NbtNames.DeliveryMechanism.SPEED] = Speed,
                [Constants.NbtNames.DeliveryMechanism.SCALE] = Scale,
                [Constants.NbtNames.DeliveryMechanism.CHARGE_TIME] = ChargeTime,
                [Constants.NbtNames.DeliveryMechanism.CASCADE_DELAY] = CascadeDelay,
                [Constants.NbtNames.DeliveryMechanism.EFFECT_DELAY] = EffectDelay,
                [Constants.NbtNames.DeliveryMechanism.COOLDOWN] = Cooldown,
                [Constants.NbtNames.DeliveryMechanism.IS_ROOT_MECHANISM] = IsRootMechanism,
                [Constants.NbtNames.DeliveryMechanism.LIFESPAN] = Lifespan,
                [Constants.NbtNames.DeliveryMechanism.DOMINANT_DUST_TYPE] = DominantDustType
            };

            return tag;
        }

        /// <summary>
        ///     Helper method of a mechanism returns the strongest weight of all its effects elements to determine visualization.
        /// </summary>
        public IElement GetDominantElement()
        {
            return Effects
                .SelectMany(e => e.Elements)
                .GroupBy(e => e.Key)
                .Select(g => new ElementWeight(g.Key, g.Sum(e => e.Value)))
                .OrderByDescending(e => e.Weight)
                .FirstOrDefault()?.Element;
        }

        /// <summary>
        ///     The type of delivery mechanism, hard coded behavior that this mechanism adheres to.
        /// </summary>
        public IDeliveryMechanismType MechanismType { get; set; }

        /// <summary>
        ///     Whether the projectile obeys gravity
        /// </summary>
        public Gravity Gravity { get; set; }

        /// <summary>
        ///     Whether or not the projectile collides with solid tiles and collided entities.
        /// </summary>
        public Corporeal Corporeal{ get; set; }

        /// <summary>
        ///     What kind of behavior does the collision resolve in:
        ///     none (dissipates/dies natural death)
        ///     bounce/ricochet
        ///     pierce (keep traveling through enemies)
        ///     linger (velocity lerps down and the mechanism lingers/continues firing resolvers on the target until it runs out)
        /// </summary>
        public CollisionBehavior CollisionBehavior { get; set; }

        /// <summary>
        ///     How many times the collision behavior fires before the mechanism needs to die. Eg. if it's piercing, how many times does it pierce? If it bounces, how many times?
        /// </summary>
        public int CollisionLimit { get; set; }

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
        public float Speed { get; set; }

        /// <summary>
        ///     How scaled-up the delivery mechanism "entity" is, determining its collision area
        /// </summary>
        public float Scale { get; set; }

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

        /// <summary>
        ///     The number of ticks the event or delivery mechanism should stay alive.
        /// </summary>
        public int Lifespan { get; set; }

        /// <summary>
        ///     The dust/visual representation of the mechanism, this is determined using the most powerful effect in the effect list.
        /// </summary>
        public int DominantDustType { get; set; }
    }
}