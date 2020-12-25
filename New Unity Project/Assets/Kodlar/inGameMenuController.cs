using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class inGameMenuController : MonoBehaviour
{
    public GameObject menuObject, ınGameController;

    public Animator levelFaderAnimator;
    public AudioSource inGameMusic;

    void Start(){
        levelFaderAnimator.SetTrigger("levelFadeIn");
    }
    public void AnaMenuyeDon(){
        SceneManager.LoadScene(0);
    }
    public void MenuAc(){
        // InGameController Devre Dışı Bırakıldı
        ınGameController.GetComponent<Animator>().SetTrigger("fadeOut");
        //Menu Controller Aktif Hale Getirildi
        menuObject.GetComponent<Animator>().SetTrigger("fadeIn"); 

    }
    public void MenuKapat(){
        // InGameController Aktif Hale Getirildi 
        ınGameController.GetComponent<Animator>().SetTrigger("fadeIn");
        //Menu Controller Devre Dışı Bırakıldı
        menuObject.GetComponent<Animator>().SetTrigger("fadeOut"); 
    }
    public void MuzikController(){
        inGameMusic.mute=!inGameMusic.mute;
    }
}
