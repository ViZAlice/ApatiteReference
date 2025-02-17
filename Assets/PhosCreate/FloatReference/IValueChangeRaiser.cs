namespace PhosCreate.FloatReference
{
    public interface IValueChangeRaiser
    {
        public void AddListener(IValueChangeListener changeListener);
        public void RemoveListener(IValueChangeListener changeListener);
    }
}