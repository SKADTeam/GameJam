using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public static AudioClip IceBallSounds, FireBallSounds;
    static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        FireBallSounds = Resources.Load<AudioClip>("FireBallSound");
        IceBallSounds = Resources.Load<AudioClip>("IceBallShotSound");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "FireBallSound":
                {
                    audioSrc.PlayOneShot(FireBallSounds);
                    break;
                }
            case "IceBallSound":
                {
                    audioSrc.PlayOneShot(IceBallSounds);
                    break;
                }
        }
    }
}
