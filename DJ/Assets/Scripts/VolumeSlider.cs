using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioMixerGroup _group;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void SetVolume()
    {
        float volume = Mathf.Max(Mathf.Log10(_slider.value) * 20, -80);

        _audioMixer.SetFloat(_group.name, volume);
    }

}