using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public float MovemntSpeed;
    public float HorSpeed;
    public float boostTimer;
    public bool boosting;
    float hor;
    public Material material;
    public Animator myAnimator;

    [SerializeField] AudioClip _Clip;

    [SerializeField] ParticleSystem particle;

    void Start()
    {
        particle.Stop();
        MovemntSpeed = 10;
        boostTimer = 0;
        boosting = false;
        material.color = Color.red;
}

void Update()
    {
        hor = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(hor * HorSpeed, 0, MovemntSpeed * Time.deltaTime));

        if (boosting == true)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 1.7f)
            {
                MovemntSpeed = 10;
                boostTimer = 0;
                boosting = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "apple")
        {
            particle.transform.position = gameObject.transform.position;
            particle.Play();
            boosting = true;
            MovemntSpeed = 25;
            CoinText.coinAmount -= 10;
            SoundManager.Instance.PlaySound(_Clip);
            Destroy(other.gameObject);    
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "finish")
        {
            myAnimator.SetBool("Run",  false);
            myAnimator.SetBool("Idle", true);        
        }
    }

}
