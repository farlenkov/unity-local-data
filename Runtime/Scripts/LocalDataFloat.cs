using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityLocalData
{
    public class LocalDataFloat : LocalDataItem<float>
    {
        public LocalDataFloat(string name, float defaultValue) : base(name, defaultValue)
        {

        }
    }
}
