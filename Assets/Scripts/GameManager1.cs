using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public Animator myAnimator;
    public GameObject playbutton;
    public GameObject pausebutton;
    public GameObject resumebutton;
    public GameObject replaybutton;
    public GameObject kart;
    public GameObject Coin;
    public Material material;
   
    void Start()
    {

       // myAnimator = GetComponent<Animator>();
        Time.timeScale = 1;
        
        pausebutton.SetActive(true);
        kart.SetActive(true);                                     // BUNU TRUE YAPMAYI UNUTMA
        Coin.SetActive(true);
       
        myAnimator.SetBool("Idle", false);
        myAnimator.SetBool("Run", true);
    }


    void Update()
    {
       
    }

    /*public void PlayGame()
    {
        //playbutton.SetActive(false);
        pausebutton.SetActive(true);
        kart.SetActive(true);                                     // BUNU TRUE YAPMAYI UNUTMA
        Coin.SetActive(true);
        Time.timeScale = 1;
        myAnimator.SetBool("Idle", false);
        myAnimator.SetBool("Run", true);

    }*/
    public void PauseGame()
    {
        Time.timeScale = 0;
        myAnimator.SetBool("Idle", true);
        myAnimator.SetBool("Run", false);
        pausebutton.SetActive(false);
        resumebutton.SetActive(true);
        replaybutton.SetActive(true);

    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        myAnimator.SetBool("Idle", false);
        myAnimator.SetBool("Run", true);
        pausebutton.SetActive(true);
        resumebutton.SetActive(false);
        replaybutton.SetActive(false);
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene(0);
        CoinText.coinAmount = 0;
        material.color = Color.red;
    }
    public void NextLevel()
    {

        CoinText.coinAmount -= 100;
        SceneManager.LoadScene(3);

    }
    public void NextLevelBus()
    {

        
        SceneManager.LoadScene(2);

    }
    public void NextLevelTelef()
    {


        SceneManager.LoadScene(4);

    }
}
