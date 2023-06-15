using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour
{
    public GameObject dayLighting;
    public GameObject eveningLighting;
    public GameObject nightLighting;

    public void Start()
    {
        setLighting();
    }

    private void setLighting()
    {
        if (ProgressManager.Instance.light == ProgressManager.LightState.Day)
        {
            setDay();
        }
        else if (ProgressManager.Instance.light == ProgressManager.LightState.Evening)
        {
            setEvening();
        }
        else
        {
            setNight();
        }
    }

    private void setDay()
    {
        dayLighting.SetActive(true);
        eveningLighting.SetActive(false);
        nightLighting.SetActive(false);
    }

    private void setEvening()
    {
        dayLighting.SetActive(false);
        eveningLighting.SetActive(true);
        nightLighting.SetActive(false);
    }

    private void setNight()
    {
        dayLighting.SetActive(false);
        eveningLighting.SetActive(false);
        nightLighting.SetActive(true);
    }
}
