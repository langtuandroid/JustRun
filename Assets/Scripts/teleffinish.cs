using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleffinish : MonoBehaviour
{
    public GameObject yazi;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            yazi.SetActive(true);
            Time.timeScale = 0;


        }

    }
}
