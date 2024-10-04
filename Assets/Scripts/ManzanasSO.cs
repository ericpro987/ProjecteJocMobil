using UnityEngine;

[CreateAssetMenu(fileName = "Manzanas", menuName = "Scriptable Objects/Manzanas")]
public class ManzanasSO : ScriptableObject
{
    public Sprite sr;
    public Vector2 velocity;
    public int punts;
    public ParticleSystem ParticleSystem;
    //public bool GameOver = false;
    }
