using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class otobusfinish : MonoBehaviour
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
