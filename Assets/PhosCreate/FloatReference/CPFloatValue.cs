using System.Collections.Generic;
using UnityEngine;

namespace PhosCreate.FloatReference
{
    [AddComponentMenu("FloatReference/CP FloatValue")]
    public class CPFloatValue : MonoBehaviour
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
                foreach (IValueListener listener in ValueListeners)
                {
                    listener.OnValueChange();
                }
            }
        }

        [SerializeField] private float _value;

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