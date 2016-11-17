using System.ComponentModel.Composition.Primitives;

namespace MEFRecipes.Contracts
{
    public interface IApplicationHost
    {
        void AddCatalog(ComposablePartCatalog catalog);
        void ComposeExport<T>(T export);
    }
}