using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsButtons : MonoBehaviour
{
    public AudioSource ClickSound;
    public AudioSource ButtonSound;
    public AudioSource PlanetSound;

    public void Click_Sound()
    {
        ClickSound.Play();
    }

    public void Button_Sound()
    {
        ButtonSound.Play();
    }

    public void Planet_Sound()
    {
        PlanetSound.Play();
    }
}
