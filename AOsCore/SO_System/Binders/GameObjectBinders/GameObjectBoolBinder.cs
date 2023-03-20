using UnityEngine;

namespace AOsCore.SO_System.Binders.GameObjectBinders
{
    public class GameObjectBoolBinder : GameObjectBinder<bool>
    {
        protected override void Refresh()
        {
            _go.SetActive(data.Value);
        }
    }
}
