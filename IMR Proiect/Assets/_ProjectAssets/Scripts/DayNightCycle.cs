using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Material[] skyboxes; 
    public float cycleDuration = 900f; 

    private int currentSkyboxIndex = 0;
    private Material currentSkybox;

    private void Start()
    {
        SetCurrentSkybox();
    }

    private void Update()
    {
        float lerpFactor = Mathf.PingPong(Time.time / cycleDuration, 1f); 
        RenderSettings.skybox.Lerp(currentSkybox, GetNextSkybox(), lerpFactor); 
    }

    private Material GetNextSkybox()
    {
        
        if (Mathf.Approximately(RenderSettings.skybox.GetFloat("_Blend"), 1f))
        {
            currentSkyboxIndex = (currentSkyboxIndex + 1) % skyboxes.Length;
            SetCurrentSkybox();
        }

        return skyboxes[currentSkyboxIndex];
    }

    private void SetCurrentSkybox()
    {
        currentSkybox = skyboxes[currentSkyboxIndex];
        RenderSettings.skybox = currentSkybox;
    }
}
