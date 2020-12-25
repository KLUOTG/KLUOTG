using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuContoller : MonoBehaviour
{
    public Animator levelFader;
    public InputField username;
    // Start is called before the first frame update
    public void SahneGecis(){
        PlayerPrefs.SetString("Username",username.text);
        StartCoroutine(LevelKapa());
    }
    IEnumerator LevelKapa(){
        levelFader.SetTrigger("levelFadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
