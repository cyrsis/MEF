using System.ComponentModel.Composition;
using Catalogs.Interface;
using Catalogs.Type;

namespace Catalogs
{
    public class ExportHost
    {
        [Export]
        public IPlugin TypeExport
        {
            get { return new TypePlugin(); }
        }
    }
}