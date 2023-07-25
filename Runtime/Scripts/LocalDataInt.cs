using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityLocalData
{
    public class LocalDataInt : LocalDataItem<int>
    {
        public LocalDataInt(string name, int defaultValue) : base(name, defaultValue)
        {

        }
    }
}
