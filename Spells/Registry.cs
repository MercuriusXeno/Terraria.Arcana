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
    }
}