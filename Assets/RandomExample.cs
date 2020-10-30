using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomExample : MonoBehaviour
{
    public AudioSource audioSrc;
    public List<AudioClip> myClips;
    void Start()
    {
        audioSrc.PlayOneShot(myClips[Random.Range(0,myClips.Count)]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
