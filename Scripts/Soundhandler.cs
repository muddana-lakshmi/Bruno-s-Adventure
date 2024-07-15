using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundhandler : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioSource adsrc;
    public static AudioClip Bark,Jump;
    void Start()
    {
        adsrc=GetComponent<AudioSource>();
        Bark=Resources.Load<AudioClip>("Bark");
        Jump=Resources.Load<AudioClip>("Jump");
    }

    // Update is called once per frame
    public static void playtheAudio(string clip)
    {
        switch(clip)
        {
            case "Bark":
                adsrc.PlayOneShot(Bark);
                break;
            case "Jump":
                adsrc.PlayOneShot(Jump);
                break;
        }
    }
}
