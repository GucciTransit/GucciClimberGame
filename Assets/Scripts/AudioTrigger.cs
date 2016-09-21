using UnityEngine;
using System.Collections;

public class AudioTrigger : MonoBehaviour
{

    public AudioClip jump1;
    public AudioClip jump2;
    public AudioClip jump3;
    public AudioClip[] myArray = new AudioClip[3];
    AudioSource Audio;
    

   
    

   
    void Start()
    {
        Audio = GetComponent<AudioSource>();
            myArray[0] = jump1;
            myArray[1] = jump2;
            myArray[2] = jump3;
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Audio.clip = myArray[Random.Range(0, 3)];
            Audio.Play();
        }
        

    }


}