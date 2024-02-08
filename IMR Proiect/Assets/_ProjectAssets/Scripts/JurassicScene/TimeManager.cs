using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private Texture2D skyboxNight;
    [SerializeField] private Texture2D skyboxSunrise;
    [SerializeField] private Texture2D skyboxDay;
    [SerializeField] private Texture2D skyboxSunset;

    [SerializeField] private Gradient graddientNightToSunrise;
    [SerializeField] private Gradient graddientSunriseToDay;
    [SerializeField] private Gradient graddientDayToSunset;
    [SerializeField] private Gradient graddientSunsetToNight;

    [SerializeField] private Light globalLight;

    private int minutes;

    public int Minutes
    { get { return minutes; } set { minutes = value; OnMinutesChange(value); } }

    private int hours = 5;

    public int Hours
    { get { return hours; } set { hours = value; OnHoursChange(value); } }

    private int days;

    public int Days
    { get { return days; } set { days = value; } }

    private float tempSecond;

    public void Update()
    {
        tempSecond += Time.deltaTime;

        if (tempSecond >= 1)
        {
            Minutes += 1;
            tempSecond = 0;
        }
    }

    private void OnMinutesChange(int value)
    {
        globalLight.transform.Rotate(Vector3.up, (1f / (1440f / 4f)) * 360f, Space.World);
        if (value >= 15)
        {
            Hours++;
            minutes = 0;
        }
        if (Hours >= 24)
        {
            Hours = 0;
            Days++;
        }
    }

    private Coroutine skyboxCoroutine;
    private Coroutine lightCoroutine;
    private void OnHoursChange(int value)
    { 
        if (skyboxCoroutine != null)
        {
            StopCoroutine(skyboxCoroutine);
        }

        if (lightCoroutine != null)
        {
            StopCoroutine(lightCoroutine);
        }

        if (value == 6)
        {
            skyboxCoroutine = StartCoroutine(LerpSkybox(skyboxNight, skyboxSunrise, 10f));
            lightCoroutine = StartCoroutine(LerpLight(graddientNightToSunrise, 10f));
        }
        else if (value == 8)
        {
            skyboxCoroutine = StartCoroutine(LerpSkybox(skyboxSunrise, skyboxDay, 10f));
            lightCoroutine = StartCoroutine(LerpLight(graddientSunriseToDay, 10f));
        }
        else if (value == 18)
        {
            skyboxCoroutine = StartCoroutine(LerpSkybox(skyboxDay, skyboxSunset, 10f));
            lightCoroutine = StartCoroutine(LerpLight(graddientDayToSunset, 10f));
        }
        else if (value == 22)
        {
            skyboxCoroutine = StartCoroutine(LerpSkybox(skyboxSunset, skyboxNight, 10f));
            lightCoroutine = StartCoroutine(LerpLight(graddientSunsetToNight, 10f));
        }
    }

   private IEnumerator LerpSkybox(Texture2D a, Texture2D b, float time)
    {
        RenderSettings.skybox.SetTexture("_Texture1", a);
        RenderSettings.skybox.SetTexture("_Texture2", b);
        RenderSettings.skybox.SetFloat("_Blend", 0);
        for (float i = 0; i < time; i += Time.deltaTime)
        {
            RenderSettings.skybox.SetFloat("_Blend", i / time);
            yield return null;
        }
        RenderSettings.skybox.SetTexture("_Texture1", b);
    }



    private IEnumerator LerpLight(Gradient lightGradient, float time)
    {
        for (float i = 0; i < time; i += Time.deltaTime)
        {
            globalLight.color = lightGradient.Evaluate(i / time);
            RenderSettings.fogColor = globalLight.color;
            yield return null;
        }
    }
}