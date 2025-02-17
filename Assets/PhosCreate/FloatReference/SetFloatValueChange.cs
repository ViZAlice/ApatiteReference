using System;
using UnityEngine;

namespace PhosCreate.FloatReference
{
    [AddComponentMenu("FloatReference/Set Float Value")]
    public class SetFloatValueChange : MonoBehaviour, IValueChangeListener
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

        void IValueChangeListener.OnValueChange()
        {
            to.Value = from.Value;
        }
    }
}