using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KediKontrol : MonoBehaviour
{
    [SerializeField]
    [Range(0,20)]
    private float hiz;
    [SerializeField]
    [Range(0, 100)]
    private float ziplamaHiz;
    

    float horizontal;
    float hareket;

    //ui
    int altinSayisi=0;
    public int saglik=100;

    public float xEkseni=0;

    Vector2 vek;
    Animator anim;
    Rigidbody2D rb;
    public LayerMask zeminLayer;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        altinSayisi = PlayerPrefs.GetInt("altinSayisi");
    }
    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        hareket += horizontal * hiz * Time.deltaTime;
        vek = new Vector2(hareket, transform.position.y);
        transform.position = vek;

        if (Input.GetButton("Jump"))
        {
            if (isYerdemi()==true)
            {
                KarakterZipla(ziplamaHiz);
            }
            
        }
        if (saglik <= 0)
        {
            saglik = 0;
        }

        if (horizontal < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (horizontal > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (horizontal != 0)
        {
            anim.SetBool("yuruyorMu", true);
        }
        else
        {
            anim.SetBool("yuruyorMu", false);
        }

    }
    IEnumerator HasarAl()
    {
        saglik -= Random.Range(7, 15);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;//vakit kalırsa animasyonda yap burayı
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);//isterseniz silebilirsiniz.
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Altin")
        {
            altinSayisi += 1;
            PlayerPrefs.SetInt("altinSayisi", altinSayisi);
            collision.gameObject.SetActive(false);
        }
        if (collision.tag == "Goblin")
        {
            StartCoroutine(HasarAl());

        }
    }
    bool isYerdemi()
    {
        Vector2 karakterPozisyon = transform.position;
        Vector2 yon = Vector2.down;
        float distance = 0.5f;
        RaycastHit2D hit = Physics2D.Raycast(karakterPozisyon, yon, distance,zeminLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
    void KarakterZipla(float ziplamaHiz)
    {
        rb.AddForce(Vector2.up*ziplamaHiz);
    }
}
