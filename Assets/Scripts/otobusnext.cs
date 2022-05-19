using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class otobusnext : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "otobus")
        {
            SceneManager.LoadScene(1);

        }
    }
}