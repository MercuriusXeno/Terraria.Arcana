using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcana.Reference
{
    public static class Constants
    {
        public static class Dust
        {
            public const string DUST = "Dust";
            public const string SMALL = "Small";
            public const string LARGE = "Large";
        }

        public const string TERRARIA_ITEM_PREFIX = "Terraria/Item_";

        public static class DeliveryMechanisms
        {
            public const string RAY = "Ray";
            public const string PULSE = "Pulse";
            public const string PROJECTILE = "Projectile";
            public const string REMOTE_INTERVENTION = "RemoteIntervention";
        }

        public static class Elements
        {
            public const string FIRE = "Fire";
            public const string EARTH = "Earth";
            public const string AIR = "Air";
            public const string WATER = "Water";
            public const string ICE = "Ice";
            public const string LIGHTNING = "Lightning";
            public const string LIGHT = "Light";
            public const string SHADOW = "Shadow";
            public const string PURITY = "Purity";
            public const string CORRUPTION = "Corruption";
            public const string ARCANE = "Arcane";
            public const string LIFE = "Life";
            public const string DEATH = "Death";
            public const string SPATIAL = "Spatial";
            public const string TEMPORAL = "Temporal";
            public const string NEUTRAL = "Neutral";
        }

        public static class NbtNames
        {
            public static class Common
            {
                public const string UNLOCALIZED_NAME = "unlocalizedName";
            }

            // arcane effects serialization
            public static class ArcaneEffect
            {
                public const string POWER = "power";
                public const string DURATION = "duration";
                public const string PRIMAL_RATIO = "primalRatio";
                public const string CORRUPT_RATIO = "corruptRatio";
                public const string EFFECT_TYPE = "effectType";
                public const string ELEMENT_KEYS = "elementKeys";
                public const string ELEMENT_VALUES = "elementValues";
                public const string BASE_COSTS = "baseCosts";
                public const string COSTS = "costs";
            }

            public static class DeliveryMechanism
            {
                public const string MECHANISM_TYPE = "mechanismType";
                public const string GRAVITY = "gravity";
                public const string CORPOREAL = "corporeal";
                public const string COLLISION_BEHAVIOR = "collisionBehavior";
                public const string COLLISION_LIMIT = "collisionLimit";
                public const string CASCADE_MECHANISMS = "cascadeMechanism";
                public const string EFFECTS = "effects";
                public const string TARGET = "target";
                public const string SEEKING = "seeking";
                public const string COUNT = "count";
                public const string REPEAT = "repeat";
                public const string REPEAT_DELAY = "repeatDelay";
                public const string SPREAD = "spread";
                public const string SPEED = "speed";
                public const string SCALE = "scale";
                public const string CHARGE_TIME = "chargeTime";
                public const string CASCADE_DELAY = "cascadeDelay";
                public const string EFFECT_DELAY = "effectDelay";
                public const string COOLDOWN = "cooldown";
                public const string IS_ROOT_MECHANISM = "isRootMechanism";
                public const string LIFESPAN = "lifespan";
                public const string DOMINANT_DUST_TYPE = "dominantDustType";
            }

            public static class PrimalCost
            {
                public const string ELEMENT = "element";
                public const string COST = "cost";
            }
        }

        public class ItemDescriptions
        {
            public const string MAGICAL_CONDUIT = "A test item, for now.";
        }

        public class Items
        {
            public const string MAGICAL_CONDUIT = "Magical Conduit";
        }
    }
}
