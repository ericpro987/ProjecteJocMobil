using System.Collections;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ManzanasSO[] m;
    [SerializeField] OBjeto m2;
    [SerializeField] Puntos p;
    int min;
    int max;
    void Start()
    {
        min = 3;
        max = 5;
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spawn() {
        while (true)
        {
            if (p.punts >= 10)
            {
                min = 1;
                max = 3;
            } else if (p.punts>= 20) {
                min = 1;
                max = 2;
            }
                
            yield return new WaitForSeconds(Random.Range(min, max));
            int sObj = Random.Range(0, 3);
             OBjeto m3 = Instantiate(m2);
            switch (sObj)
            {

                case 0:
                    m3.setManzana(m[0]);
                    break;
                case 1:
                    m3.setManzana(m[1]);
                    break;
                case 2:
                    m3.setManzana(m[2]);
                    break;
            }
        }
    }
}
