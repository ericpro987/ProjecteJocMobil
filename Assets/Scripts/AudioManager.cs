using System.Linq.Expressions;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip a;
    [SerializeField] AudioClip b;
    [SerializeField] AudioClip c;

    [SerializeField] AudioSource aus;
    [SerializeField] AudioSource aus2;
    [SerializeField] AudioSource aus3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  
        aus.clip = a;
        aus.loop = true;
        aus.volume = aus.maxDistance;
        aus.Play();
    }
    public void a2()
    {
        aus2.clip = b;
        aus2.loop = false;
        aus2.volume = aus2.maxDistance;
        aus2.Play();
    }
    public void a3()
    {
        aus2.clip = c;
        aus2.loop = false;
        aus2.volume = aus2.maxDistance;
        aus2.Play();
    }
}
