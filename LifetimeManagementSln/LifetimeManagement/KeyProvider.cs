using System;
using System.ComponentModel.Composition;

namespace LifetimeManagement
{   
    [Export(typeof(IKeyProvider))]
    public class KeyProvider : IKeyProvider
    {
        private Guid _guid = Guid.NewGuid();

        public string Key
        {
            get { return _guid.ToString(); }
        }
    }
}