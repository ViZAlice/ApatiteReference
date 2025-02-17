using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace PhosCreate.FloatReference
{
    [CreateAssetMenu(fileName = "new float value", menuName = "FloatReference/SO FloatValue", order = 0)]
    public class SOFloatValue : ScriptableObject
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
                foreach (IValueListener listener in ValueListeners)
                {
                    listener.OnValueChange();
                }
            }
        }

        [SerializeField, HideInInspector] private float _value;

        public List<IValueListener> ValueListeners = new();
        [SerializeReference] private SaveMode _saveMode;

        public void AddListener(IValueListener listener)
        {
            ValueListeners.Add(listener);
        }

        public void RemoveListener(IValueListener listener)
        {
            ValueListeners.Remove(listener);
        }
    }
}