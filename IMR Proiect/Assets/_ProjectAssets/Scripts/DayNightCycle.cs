// using UnityEngine;

// public class DayNightCycle : MonoBehaviour
// {
//     public Material[] skyboxes; 
//     public float cycleDuration = 20f; 

//     private int currentSkyboxIndex = 0;

//     private void Update()
//     {
//         float lerpFactor = Mathf.PingPong(Time.time / cycleDuration, 1f); 
//         RenderSettings.skybox = GetNextSkybox(lerpFactor);
//     }

//     private Material GetNextSkybox(float lerpFactor)
//     {
//         if (lerpFactor >= 1f)
//         {
//             currentSkyboxIndex = (currentSkyboxIndex + 1) % skyboxes.Length;
//         }

//         return skyboxes[currentSkyboxIndex];
//     }
// }
