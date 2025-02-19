using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace PhosCreate.FloatReference
{
    [Serializable]
    public class FloatValueSlot
    {
        [BoxGroup]
        [SerializeReference] private SlotType slotType = new Local();

        public float Value
        {
            get => slotType.Value;
            set => slotType.Value = value;
        }

        public void AddListener(IValueChangeListener changeListener) => slotType.LocalValueChangeRaiser.AddListener(changeListener);
        public void RemoveListener(IValueChangeListener changeListener) => slotType.LocalValueChangeRaiser.RemoveListener(changeListener);


        private abstract class SlotType
        {
            public abstract float Value { get; set; }
            public abstract IValueChangeRaiser LocalValueChangeRaiser { get; }
        }

        [Serializable]
        class ScriptObject : SlotType
        {
            [SerializeField] private SOFloatValue scriptableobject;

            public override float Value
            {
                get => scriptableobject.Value;
                set => scriptableobject.Value = value;
            }

            public override IValueChangeRaiser LocalValueChangeRaiser => scriptableobject;
        }

        [Serializable]
        class Component : SlotType
        {
            [SerializeField] private CPFloatValue component;

            public override float Value
            {
                get => component.Value;
                set => component.Value = value;
            }

            public override IValueChangeRaiser LocalValueChangeRaiser => component;
        }

        [Serializable]
        class Local : SlotType
        {
            [SerializeField] private LocalFloatValue localValue;

            public override float Value
            {
                get => localValue.Value;
                set => localValue.Value = value;
            }

            public override IValueChangeRaiser LocalValueChangeRaiser => localValue;
        }
    }
}