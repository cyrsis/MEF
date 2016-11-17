using System;

namespace LifeManagementSilverlight
{
    public class KeyProvider : IKeyProvider
    {
        private Guid _guid = Guid.NewGuid();
        public string Key
        {
            get { return _guid.ToString(); }
        }
    }
}