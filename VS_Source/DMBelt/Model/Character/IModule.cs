using System;
using System.Collections.Generic;

namespace DMBelt.Model.Character
{
    public interface IModule
    {
        string ModuleName { get; }
        object GetProperty(string property);
        void SetProperty(string property, object value);
        List<Object> Export();
    }
}
