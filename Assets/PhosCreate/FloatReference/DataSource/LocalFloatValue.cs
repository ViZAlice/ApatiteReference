using System;
using System.Collections.Generic;
using UnityEngine;

namespace PhosCreate.FloatReference
{
    [Serializable]
    public class LocalFloatValue: IValueChangeRaiser
    {
        public float Value
        {
            get => _value;
            set
            {
                if (Mathf.Approximately(_value, value))
                {
                    return;
                }

                _value = value;
                foreach (IValueChangeListener listener in ValueListeners)
                {
                    listener.OnValueChange();
                }
            }
        }

        [SerializeField] private float _value;

        public List<IValueChangeListener> ValueListeners = new();
        [SerializeReference] private SaveMode _saveMode;

        public void AddListener(IValueChangeListener changeListener)
        {
            ValueListeners.Add(changeListener);
        }

        public void RemoveListener(IValueChangeListener changeListener)
        {
            ValueListeners.Remove(changeListener);
        }
    }
}