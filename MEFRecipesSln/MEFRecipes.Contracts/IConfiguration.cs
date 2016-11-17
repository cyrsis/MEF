using System;

namespace MEFRecipes.Contracts
{
    public interface IConfiguration
    {
        Uri FeedUri { get; }
        string Mode { get; }
    }
}