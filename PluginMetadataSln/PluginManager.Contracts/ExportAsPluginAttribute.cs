using System;
using System.ComponentModel.Composition;

namespace PluginManager.Contracts
{   
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false)]
    public class ExportAsPluginAttribute : ExportAttribute, IPluginMetadata
    {
        public ExportAsPluginAttribute() : base(typeof(IPluginPart))
        {
            
        }

        public Positions Position { get; set; }
    }
}