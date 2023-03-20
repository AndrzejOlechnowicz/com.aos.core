using AOsCore.SO_System.UIBinders;
using TMPro;

namespace AOsCore.SO_System.Binders.TMProBinders
{
    public class TextBinder<T> : DataBinder<T>
    {
        protected TextMeshProUGUI _text;

        protected void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        protected override void Refresh()
        {
            _text.text = data.ToString();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            Refresh();
        }
    }
}
