using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using WebmilioCommons.Loaders;

namespace Arcana.Spells.Elements
{
    public sealed class ElementLoader : SingletonLoader<ElementLoader, IElement>
    {
        private Dictionary<string, IElement> _genericByName;


        public override void PreLoad() => _genericByName = new Dictionary<string, IElement>();

        protected override void PostUnload() => _genericByName = null;


        protected override void PostAdd(Mod mod, IElement item, Type type) => _genericByName.Add(item.Name, item);


        public IElement GetGeneric(string name) => _genericByName[name];


        // I'm not sure what to do with GetHashCode() so change it if its not ok.
        private class IgnoreCaseComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y) => x.Equals(y, StringComparison.CurrentCultureIgnoreCase);

            public int GetHashCode(string obj) => obj.GetHashCode();
        }
    }
}