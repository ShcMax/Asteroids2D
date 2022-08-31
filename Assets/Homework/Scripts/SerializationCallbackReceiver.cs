using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Prototype.Scripts
{
    [Serializable]
    public class SerializationCallbackReceiver<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [SerializeField, HideInInspector]

        private List<TKey> keys = new List<TKey>();

        [SerializeField, HideInInspector]

        private List<TValue> values = new List<TValue>();


        public Dictionary<TKey, TValue> serializedDictionary
        {
            get;
            private set;
        }

        public void OnBeforeSerialize()
        {
            foreach (var item in serializedDictionary)
            {
                if (!keys.Contains(item.Key))
                    keys.Add(item.Key);

                if (!values.Contains(item.Value))
                    values.Add(item.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            serializedDictionary = new Dictionary<TKey, TValue>();
            for (var i = 0; i < keys.Count; i++)
            {
                serializedDictionary[keys[i]] = values[i];
            }
        }

        void Info()
        {
            foreach (var test in serializedDictionary)
            {
                Debug.Log("Key " + test.Key + "value " + test.Value);
            }
        }
    }
}



