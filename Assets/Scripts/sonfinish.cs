using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonfinish : MonoBehaviour
{
    public GameObject yazi;
    public Animator kartAnimator;
    public Animator myAnimator;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            yazi.SetActive(true);
            myAnimator.SetBool("Run", false);
            myAnimator.SetBool("Idle", true);
            kartAnimator.enabled = true;
            Time.timeScale = 0;

        }
    }
}
