using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyucu : MonoBehaviour
{
    GameObject kedi;
    float yonBelirle;
    public GameObject mermi;
    public bool atesEt;
    float mesafe;

    void Start()
    {
        kedi = GameObject.Find("OyuncuKedi");
        mermi.SetActive(false);
        atesEt = false;
    }
    void Update()
    {
        mesafe = Vector2.Distance(transform.position, kedi.transform.position);
        if (mesafe <= 5&&atesEt==false)
        {
            atesEt = true;
        }
        if (atesEt)
        {
            AtesEt();
        }
        if (mermi.GetComponent<Mermi>().GetVurduMu() == true)
        {
            Sifirla();
        }
        if (mermi.GetComponent<Mermi>().GetFark()<0&&yonBelirle<0)
        {
            Sifirla();
        }
        else if (mermi.GetComponent<Mermi>().GetFark() > 0 && yonBelirle > 0)
        {
            Sifirla();
        }
        YonBul();
    }
    public void Sifirla()
    {
        mermi.transform.position = transform.position;
        mermi.SetActive(false);
        mermi.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        mermi.GetComponent<Mermi>().SetVurduMu(false);
    }
    public void YonBul()
    {
        
        yonBelirle = kedi.transform.position.x - transform.position.x;
        if (yonBelirle > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }
        else if (yonBelirle < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

        }
    }
    public void AtesEt()
    {
        mermi.SetActive(true);
        if (yonBelirle > 0)
        {
            mermi.GetComponent<Mermi>().SagaAtes();

        }
        else if (yonBelirle < 0)
        {
            mermi.GetComponent<Mermi>().SolaAtes();
        }
    }
}
