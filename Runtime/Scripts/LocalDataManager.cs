using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.Assertions.Must;
using UnityUtility;

namespace UnityLocalData
{
    public class LocalDataManager
    {
        Dictionary<string, LocalDataInt> IntItems = new();
        Dictionary<string, LocalDataFloat> FloatItems = new();
        Dictionary<string, LocalDataString> StringItems = new();

        public LocalDataInt GetInt(string name, int defaultValue = 0)
        {
            if (IntItems.TryGetValue(name, out var item))
                return item;

            item = new LocalDataInt(name, defaultValue);
            IntItems.Add(name, item);

            Load(item);
            item.Subscribe(value => Save(item));
            return item;
        }

        public LocalDataFloat GetFloat(string name, float defaultValue = 0)
        {
            if (FloatItems.TryGetValue(name, out var item))
                return item;

            item = new LocalDataFloat(name, defaultValue);
            FloatItems.Add(name, item);

            Load(item);
            item.Subscribe(value => Save(item));
            return item;
        }

        public LocalDataString GetString(string name, string defaultValue = null)
        {
            if (StringItems.TryGetValue(name, out var item))
                return item;

            item = new LocalDataString(name, defaultValue);
            StringItems.Add(name, item);

            Load(item);
            item.Subscribe(value => Save(item));
            return item;
        }

        void Load(LocalDataInt item)
        {
            item.Value = PlayerPrefs.HasKey(item.Name)
                ? PlayerPrefs.GetInt(item.Name, item.DefaultValue)
                : item.DefaultValue;
        }

        void Load(LocalDataFloat item)
        {
            item.Value = PlayerPrefs.HasKey(item.Name)
                ? PlayerPrefs.GetFloat(item.Name, item.DefaultValue)
                : item.DefaultValue;
        }

        void Load(LocalDataString item)
        {
            item.Value = PlayerPrefs.HasKey(item.Name)
                ? PlayerPrefs.GetString(item.Name, item.DefaultValue)
                : item.DefaultValue;
        }

        void Save(LocalDataInt item)
        {
            if (item.Value == item.DefaultValue)
                PlayerPrefs.DeleteKey(item.Name);
            else
                PlayerPrefs.SetInt(item.Name, item.Value);
        }

        void Save(LocalDataFloat item)
        {
            if (item.Value == item.DefaultValue)
                PlayerPrefs.DeleteKey(item.Name);
            else
                PlayerPrefs.SetFloat(item.Name, item.Value);
        }

        void Save(LocalDataString item)
        {
            if (item.Value == item.DefaultValue)
                PlayerPrefs.DeleteKey(item.Name);
            else
                PlayerPrefs.SetString(item.Name, item.Value);
        }
    }
}