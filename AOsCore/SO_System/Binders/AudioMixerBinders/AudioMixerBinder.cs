using AOsCore.SO_System.UIBinders;
using UnityEngine;
using UnityEngine.Audio;

namespace AOsCore.SO_System.Binders.AudioMixerBinders
{
    public class AudioMixerBinder<T> : DataBinder<T>
    {
        [SerializeField] protected AudioMixer mixer;
        [SerializeField] protected string audioMixerExposedParameterName;
        

        protected override void Refresh()
        {
            //mixer.SetFloat(audioMixerExposedParameterName, data);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            Refresh();
        }
        
    }
}
