using UnityEngine;

public class AudioControl : MonoBehaviour {

 
    public AudioClip Memes;
    AudioSource Audio;

    void Start () {
       Audio = GetComponent<AudioSource>();
    }
	

	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            Audio.clip = Memes;
            Audio.Play();
        }

    }
}
