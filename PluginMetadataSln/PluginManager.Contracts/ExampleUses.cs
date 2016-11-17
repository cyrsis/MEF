namespace PluginManager.Contracts
{ 
    /// <summary>
    ///     Informational
    /// </summary>
    public enum Routing
    {
        Left,
        Right
    }

    public interface IWidget
    {
        Routing Position { get; }
    }

    /// <summary>
    ///     Capabilities
    /// </summary>
    public enum Capabilities : short
    {
        Email = 0x1,
        FileSystemAccess = 0x2,
        InternetConnection = 0x4
    }

    public interface IDataExportMetadata 
    {
        short Capabilities { get; }        
    }

    public enum Limitations
    {
        Debug,
        Production
    }

    /// <summary>
    ///     Requirements/Limitations
    /// </summary>
    public interface ILogExportMetadata
    {
        Limitations TargetEnvironment { get; }
    }

    
}
