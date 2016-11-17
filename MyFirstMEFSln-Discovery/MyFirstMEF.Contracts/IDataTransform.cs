using System.ComponentModel.Composition;

namespace MyFirstMEF.Contracts
{
    [InheritedExport]
    public interface IDataTransform
    {        
        void Transform();
    }
}