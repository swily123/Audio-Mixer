using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolumeChanger : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioMixer _audioMixer;

    private float _originalVolumeMaster;
    private float _value;
    private bool _isPlaying = true;

    private void Start()
    {
        SetMasterVolume();
        SetMusicVolume();
        SetEffectsVolume();
    }

    public void SetMasterVolume()
    {
        if (_slider != null)
        {
            _audioMixer.SetFloat("Master", GetVolume());
        }
    }

    public void SetMusicVolume()
    {
        if (_slider != null)
        {
            _audioMixer.SetFloat("Music", GetVolume());
        }
    }

    public void SetEffectsVolume()
    {
        if (_slider != null)
        {
            _audioMixer.SetFloat("Effects", GetVolume());
        }
    }

    public void ToggleMusic()
    {
        _isPlaying = !_isPlaying;

        if (_isPlaying)
        {
            _audioMixer.SetFloat("Master", _originalVolumeMaster);
        }
        else
        {
            _audioMixer.GetFloat("Master", out float volume);
            _originalVolumeMaster = volume;
            _audioMixer.SetFloat("Master", -80);
        }
    }

    private float GetVolume()
    {
        _value = _slider.value;
        return Mathf.Max(Mathf.Log10(_value) * 20, -80);
    }
}
