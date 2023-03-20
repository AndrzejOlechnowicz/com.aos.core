using AOsCore.SO_System.UIBinders;
using UnityEngine;

namespace AOsCore.SO_System.Binders.GameObjectBinders
{
    public class GameObjectBinder<T> : DataBinder<T>
    {
        [SerializeField] protected GameObject _go;
        [SerializeField] private bool shouldLoadRefOnAwake;
        
        private void Awake()
        {
            if (shouldLoadRefOnAwake)
            {
                _go = gameObject;
            }
        }
        
        protected override void Refresh()
        {
            throw new System.NotImplementedException();
        }
        
        protected override void OnEnable()
        {
            base.OnEnable();
            Refresh();
        }
    }
}
