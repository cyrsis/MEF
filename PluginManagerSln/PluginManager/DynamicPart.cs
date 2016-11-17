using System;
using System.Windows.Controls;
using PluginManager.Contracts;

namespace PluginManager
{
    public class DynamicPart : IPluginPart
    {
        private readonly UserControl _control; 

        public DynamicPart(UserControl control)
        {
            _control = control;
        }

        public UserControl Part
        {
            get { return _control; }
        }
    }
}