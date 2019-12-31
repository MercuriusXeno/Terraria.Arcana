using System.Collections.Generic;
using Arcana.Reference;
using Arcana.Spells.DeliveryMechanisms;
using Arcana.Spells.Elements;

namespace Arcana.Spells
{
    /// <summary>
    ///     Class representing registries for holding exposable dictionaries. Used to house the mods logic holders, like delivery mechanisms
    ///     and arcane effects.
    /// </summary>
    public class Registry
    {
        private static IDeliveryMechanism _projectile = new Projectile();
        private static IDeliveryMechanism _pulse = new Pulse();
        private static IDeliveryMechanism _ray = new Ray();
        private static IDeliveryMechanism _remoteIntervention = new RemoteIntervention();
        public static Dictionary<string, IDeliveryMechanism> MechanismRegistry = new Dictionary<string, IDeliveryMechanism>
        {
            [key: Constants.DeliveryMechanisms.Projectile] = _projectile,
            [Constants.DeliveryMechanisms.Pulse] = _pulse,
            [Constants.DeliveryMechanisms.Ray] = _ray,
            [Constants.DeliveryMechanisms.RemoteIntervention] = _remoteIntervention
        };


        private static IElement _neutral = new Neutral();
        private static IElement _fire = new Fire();
        private static IElement _earth = new Earth();
        private static IElement _air = new Air();
        private static IElement _water = new Water();
        private static IElement _ice = new Ice();
        private static IElement _lightning = new Lightning();
        private static IElement _light = new Light();
        private static IElement _shadow = new Shadow();
        private static IElement _purity = new Purity();
        private static IElement _corruption = new Corruption();
        private static IElement _arcane = new Arcane();
        private static IElement _life = new Life();
        private static IElement _death = new Death();
        private static IElement _spatial = new Spatial();
        private static IElement _temporal = new Temporal();
        public static Dictionary<string, IElement> ElementRegistry = new Dictionary<string, IElement>
        {
            [Constants.Elements.Neutral] = _neutral,
            [Constants.Elements.Fire] = _fire,
            [Constants.Elements.Earth] = _earth,
            [Constants.Elements.Air] = _air,
            [Constants.Elements.Water] = _water,
            [Constants.Elements.Ice] = _ice,
            [Constants.Elements.Lightning] = _lightning,
            [Constants.Elements.Light] = _light,
            [Constants.Elements.Shadow] = _shadow,
            [Constants.Elements.Purity] = _purity,
            [Constants.Elements.Corruption] = _corruption,
            [Constants.Elements.Arcane] = _arcane,
            [Constants.Elements.Life] = _life,
            [Constants.Elements.Death] = _death,
            [Constants.Elements.Spatial] = _spatial,
            [Constants.Elements.Temporal] = _temporal
        };
    }
}