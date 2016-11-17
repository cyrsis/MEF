using System.ComponentModel.Composition;

namespace LifeManagementSilverlight
{
    [InheritedExport]
    public interface IKeyProvider
    {
        string Key { get; }       
    }
}