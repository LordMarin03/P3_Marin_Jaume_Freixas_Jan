using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    private Volume volume;
    [SerializeField]
    private Slider redValueSlider;
    [SerializeField]
    private Slider greenValueSlider;
    [SerializeField]
    private Slider blueValueSlider;

    private ChannelMixer channelMixer;

    void Start()
    {
        if (volume == null)
        {
            Debug.LogError("Volume is not assigned.");
            return;
        }

        if (redValueSlider == null || greenValueSlider == null || blueValueSlider == null)
        {
            Debug.LogError("One or more sliders are not assigned.");
            return;
        }

        // Initialize the channel mixer reference
        if (volume.profile.TryGet(out channelMixer))
        {
            // Set initial slider values to match current channel mixer values
            redValueSlider.value = channelMixer.redOutRedIn.value;
            greenValueSlider.value = channelMixer.greenOutGreenIn.value;
            blueValueSlider.value = channelMixer.blueOutBlueIn.value;

            // Assign the methods to be called when the slider values change
            redValueSlider.onValueChanged.AddListener(OnRedValueChanged);
            greenValueSlider.onValueChanged.AddListener(OnGreenValueChanged);
            blueValueSlider.onValueChanged.AddListener(OnBlueValueChanged);
        }
        else
        {
            Debug.LogError("Channel Mixer is not found in the Volume profile.");
        }
    }

    void OnRedValueChanged(float value)
    {
        if (channelMixer != null)
        {
            channelMixer.redOutRedIn.value = value;
        }
    }

    void OnGreenValueChanged(float value)
    {
        if (channelMixer != null)
        {
            channelMixer.greenOutGreenIn.value = value;
        }
    }

    void OnBlueValueChanged(float value)
    {
        if (channelMixer != null)
        {
            channelMixer.blueOutBlueIn.value = value;
        }
    }
}
