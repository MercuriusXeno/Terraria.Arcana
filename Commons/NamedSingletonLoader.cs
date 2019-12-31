using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using WebmilioCommons.Loaders;
using WebmilioCommons.Managers;

namespace Arcana.Commons
{
    public abstract class NamedSingletonLoader<TLoader, TLoaderOf> : SingletonLoader<TLoader, TLoaderOf> where TLoader : SingletonLoader<TLoader, TLoaderOf>, new() where TLoaderOf : class, IHasUnlocalizedName
    {
        protected Dictionary<string, TLoaderOf> genericByUnlocalizedNames;


        public override void PreLoad() => genericByUnlocalizedNames = new Dictionary<string, TLoaderOf>(new IgnoreCaseComparer());

        protected override void PostUnload() => genericByUnlocalizedNames = null;


        protected override void PostAdd(Mod mod, TLoaderOf item, Type type) => genericByUnlocalizedNames.Add(item.UnlocalizedName, item);


        public TLoaderOf GetGeneric(string name) => genericByUnlocalizedNames[name];


        // I'm not sure what to do with GetHashCode() so change it if its not ok.
        private class IgnoreCaseComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y) => x.Equals(y, StringComparison.CurrentCultureIgnoreCase);

            public int GetHashCode(string obj) => obj.GetHashCode();
        }
    }
}