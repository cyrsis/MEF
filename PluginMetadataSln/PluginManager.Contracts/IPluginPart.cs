using System.Windows.Controls;

namespace PluginManager.Contracts
{
    public interface IPluginPart
    {
        UserControl Part { get; }
    }
}