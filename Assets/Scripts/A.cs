using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class A : MonoBehaviour
{


    public void NextLevelBus()
    {
        SceneManager.LoadScene(2);
    }
}
