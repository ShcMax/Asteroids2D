using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Prototype.Scripts
{
    public class PrototypeExample : MonoBehaviour, ISerializationCallbackReceiver
    {

        public List<int> _keys = new List<int> { 3, 4, 5 };
        public List<string> _values = new List<string> {"M","A","X" };

        public Dictionary<int, string> _myDictionary = new Dictionary<int, string>();
             

        [SerializeField]
        private MyCloneableObject _origin;

        int count = 5;
        float timer = 2;
        float _timeEnd = 0;       

        private void Update()
        {
            timer = timer - Time.deltaTime;
            for (int i = 0; i < count; i++)
            {
                if(timer <= _timeEnd)
                {
                    timer = 2;
                    TestPrototype();
                }
            }  
        }

        //[ContextMenu("Test DotNet Cloneable")]
        //private void TestDotNetCloneable()
        //{
        //    var origin = PlayerDataFactory.CreateCloneablePlayerData();
        //    var clone = (CloneablePlayerData)origin.Clone();

        //    origin.Speed = 666;
        //    origin.HealthData.CurrentHealth = 37;

        //    Debug.Log($"PrototypeExample.TestDotNetCloneable: origin.Speed = {origin.Speed}; clone.Speed = {clone.Speed}");
        //    Debug.Log($"PrototypeExample.TestDotNetCloneable: origin.CurrentHealth = {origin.HealthData.CurrentHealth}; clone.CurrentHealth = {clone.HealthData.CurrentHealth}");
        //}

        //[ContextMenu("Test Deep Copy")]
        //private void TestDeepCopy()
        //{
        //    var origin = PlayerDataFactory.CreatePlayerData();
        //    var deepCopy = origin.DeepCopy();

        //    origin.Speed = 42;
        //    origin.HealthData.CurrentHealth = 43;

        //    Debug.Log($"PrototypeExample.TestDeepCopy: origin.Speed = {origin.Speed}; deepCopy.Speed = {deepCopy.Speed}");
        //    Debug.Log($"PrototypeExample.TestDeepCopy: origin.CurrentHealth = {origin.HealthData.CurrentHealth}; deepCopy.CurrentHealth = {deepCopy.HealthData.CurrentHealth}");
        //}



        [ContextMenu("Test Prototype")]
        private void TestPrototype()
        {
            var newObject = _origin.Clone();
            var newObjectCasted = (MyCloneableObject)newObject;
            Debug.Log("PrototypeExample.TestPrototype: newObjectCasted.name = " + newObjectCasted.name);
        }
        
        //[ContextMenu("Test Instantiate")]
        //private void TestInstantiate()
        //{
        //    var newObject = Instantiate(_origin);
        //    newObject.transform.position += Vector3.left;
        //}

        public void OnBeforeSerialize()
        {
            _keys.Clear();
            _values.Clear();

            foreach (var kvp in _myDictionary)
            {
                _keys.Add(kvp.Key);
                _values.Add(kvp.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            _myDictionary = new Dictionary<int, string>();
            for(int i = 0; i != Math.Min(_keys.Count, _values.Count); i++)
            {
                _myDictionary.Add(_keys[i], _values[i]);
            }
        }

        void Info()
        {
            foreach (var kvp in _myDictionary)
            {
                Debug.Log("Key" + kvp.Key + "value" + kvp.Value);
            }
        }
    }
}