using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace PhosCreate.FloatReference
{
    [CreateAssetMenu(fileName = "new float value", menuName = "FloatReference/SO FloatValue", order = 0)]
    public class SOFloatValue : ScriptableObject, IValueChangeRaiser
    {
        [ShowInInspector]
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

        [SerializeField, HideInInspector] private float _value;

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