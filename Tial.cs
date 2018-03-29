using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tial : MonoBehaviour
{
    public int index;
    public string levelName;

    public Image transitionImage;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Right away
            StartCoroutine(Fading());
            //Or 
            //StartCoroutine(Fading());
        }
    }
    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => transitionImage.color.a == 1);
        SceneManager.LoadScene(index);
    }
}
