using System.Linq.Expressions;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip a;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSource aus = new AudioSource();
        aus.clip = a;
        aus.loop = true;
        aus.volume = aus.maxDistance;
        aus.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
