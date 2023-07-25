using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityLocalData
{
    public class LocalDataString : LocalDataItem<string>
    {
        public LocalDataString(string name, string defaultValue) : base(name, defaultValue)
        {

        }
    }
}
