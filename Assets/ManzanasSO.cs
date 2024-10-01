using UnityEngine;

[CreateAssetMenu(fileName = "Manzanas", menuName = "Scriptable Objects/Manzanas")]
public class ManzanasSO : ScriptableObject
{
    public Sprite sr;
    public Vector2 velocity;
    public Vector3 Scale;
    public float RadiusCollider;
    public int punts;
    public AudioClip audio;
}
