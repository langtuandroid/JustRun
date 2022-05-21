using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject zemin;
    public GameObject otobüs;
    public GameObject next;
    public Animator myAnimator;
    public Animator kartAnimator;

    [SerializeField] AudioClip _Clip;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            zemin.SetActive(true);
            otobüs.SetActive(true);
            next.SetActive(true);
            Time.timeScale = 0;
            myAnimator.SetBool("otobüs", true);
            kartAnimator.enabled = true;
            SoundManager.Instance.PlaySound(_Clip);
        }

        
    }
}
