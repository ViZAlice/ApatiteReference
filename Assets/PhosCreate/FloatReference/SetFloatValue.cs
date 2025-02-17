using System;
using UnityEngine;

namespace PhosCreate.FloatReference
{
    [AddComponentMenu("FloatReference/Set Float Value")]
    public class SetFloatValue : MonoBehaviour, IValueListener
    {
        [SerializeField] public FloatValueSlot from;
        [SerializeField] public FloatValueSlot to;

        private void OnEnable()
        {
            from.AddListener(this);
        }

        private void OnDisable()
        {
            from.RemoveListener(this);
        }

        void IValueListener.OnValueChange()
        {
            to.Value = from.Value;
        }
    }
}