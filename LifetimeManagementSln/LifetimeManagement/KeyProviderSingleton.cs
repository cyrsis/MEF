using System;

namespace LifetimeManagement
{
    public class KeyProviderSingleton : IKeyProvider 
    {
        private KeyProviderSingleton()
        {
            
        }

        private static readonly KeyProviderSingleton _instance = new KeyProviderSingleton();        

        public static KeyProviderSingleton Instance
        {
            get { return _instance; }
        }

        public string Key
        {
            get { return "The Key"; }
        }
    }
}