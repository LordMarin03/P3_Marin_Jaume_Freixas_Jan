using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{
    public Material initialSkybox;
    public Material newSkybox;
    public float delay = 20f;

    void Start()
    {
        RenderSettings.skybox = initialSkybox;
        StartCoroutine(ChangeSkyboxAfterDelay());
    }

    System.Collections.IEnumerator ChangeSkyboxAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        RenderSettings.skybox = newSkybox;
        DynamicGI.UpdateEnvironment();
    }
}
