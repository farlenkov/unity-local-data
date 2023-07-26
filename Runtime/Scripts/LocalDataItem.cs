using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace UnityLocalData
{
    public class LocalDataItem<T> : ReactiveProperty<T>
    {
        internal string Name { get; private set; }
        internal T DefaultValue { get; private set; }

        internal LocalDataItem(string name, T defaultValue)
        {
            Name = name;
            DefaultValue = defaultValue;
        }

        public void Reset()
        {
            Value = DefaultValue;
        }
    }
}
