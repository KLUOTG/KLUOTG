using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    GameObject kedi;
    float mesafe;
    [SerializeField]
    [Range(0, 10)]
    private float hiz;
    float yonBelirle;
    bool kovala;
    void Start()
    {
        kedi = GameObject.Find("OyuncuKedi");
        kovala = false;
    }

    
    void Update()
    {
        YonBul();
        mesafe = Vector2.Distance(transform.position, kedi.transform.position);
        if (mesafe <= 2f&&kovala==false)
        {
            kovala = true;
        }
        if (kedi.GetComponent<KediKontrol>().GetKediCan() <= 0)
        {
            kovala = false;
        }
        if (kovala)
        {
            Kovala();
        }
    }
    public void YonBul()
    {
        yonBelirle = kedi.transform.position.x-transform.position.x;
        if (yonBelirle > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (yonBelirle < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    public void Kovala()
    {
        transform.position = Vector2.MoveTowards(transform.position, kedi.transform.position, hiz * Time.deltaTime);
    }
}
