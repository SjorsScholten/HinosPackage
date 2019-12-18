namespace HinosPackage.Runtime.Util {
    public abstract class DirtyProp<T> {
        private T baseValue;
        private T _value;
        
        public T Value {
            get {
                if (isDirty) {
                    _value = CalculateFinalValue();
                    isDirty = false;
                }
                return _value;
            }
        }

        protected bool isDirty = true;

        protected abstract T CalculateFinalValue();
    }
}