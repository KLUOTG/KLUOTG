using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    [Range(0, 20)]
    float hiz;
    bool isVurdu;
    GameObject kedi;
    bool isIska;
    float fark = 0;
    
    void Start()
    {
        kedi = GameObject.Find("OyuncuKedi");
        rb = gameObject.GetComponent<Rigidbody2D>();
        isVurdu = false;
    }

    void Update()
    {
        fark = transform.position.x - kedi.transform.position.x;
    }
    public float GetFark()
    {
        return fark;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Kedi")
        {
            isVurdu = true;
        }
    }
    public bool GetVurduMu()
    {
        return isVurdu;
    }
    public void SetVurduMu(bool a)
    {
        isVurdu = a;
    }
    public void SolaAtes()
    {
        rb.AddForce(Vector2.left * hiz);
    }
    public void SagaAtes()
    {
        rb.AddForce(Vector2.right * hiz);
    }
}
