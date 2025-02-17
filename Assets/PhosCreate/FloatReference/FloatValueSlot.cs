using System;
using System.Collections.Generic;
using UnityEngine;

namespace PhosCreate.FloatReference
{
    [Serializable]
    public class FloatValueSlot
    {
        [SerializeReference]
        private SlotType slotType;

        public float Value
        {
            get => _value.Value;
            set => _value.Value = value;
        }

        public SOFloatValue _value;

        public void AddListener(IValueListener listener) => _value.AddListener(listener);
        public void RemoveListener(IValueListener listener) => _value.RemoveListener(listener);

        private abstract class SlotType
        {
            public abstract float Value { get; set;}
        }

        class ScriptObject
        {

        }
    }
}