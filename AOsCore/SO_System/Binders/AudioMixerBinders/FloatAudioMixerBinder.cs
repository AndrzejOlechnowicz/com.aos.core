using UnityEngine;

namespace AOsCore.SO_System.Binders.AudioMixerBinders
{
    public class FloatAudioMixerBinder : AudioMixerBinder<float>
    {
        protected override void Refresh()
        {
            var mixerValue = Mathf.Log10(data) * 20;
            mixer.SetFloat(audioMixerExposedParameterName, mixerValue);
        }
    }
}
