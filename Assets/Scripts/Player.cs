using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    private float MovemntSpeed;
    private float HorSpeed;
    private float hor;

    public float boostTimer;
    public bool boosting;

    public Material material;
    public Animator myAnimator;

    [SerializeField] AudioClip _Clip;

    [SerializeField] ParticleSystem particle;

    private float xSpeed;
    private float _currentRunningSpeed;
    private float limitX;

    public Rigidbody Rigidbody;
    bool sag;
    bool sol;
    float speed = 14f;
    void Start()
    {
        particle.Stop();
        _currentRunningSpeed = 11;
        boostTimer = 0;
        boosting = false;
        material.color = Color.red;
}

    void Update()
{
        transform.Translate(0, 0, speed * Time.deltaTime);
        Vector3 sag_git = new Vector3(3.80f, transform.position.y, transform.position.z);
        Vector3 sol_git = new Vector3(-3.80f, transform.position.y, transform.position.z);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.deltaPosition.x  > 50f)
            {
                sag = true;
                sol = false;
            }
            if (touch.deltaPosition.x < -50f)
            {
                sag = false;
                sol = true;
            }
            if(sag == true)
            {
                transform.position = Vector3.Lerp(transform.position, sag_git, 4f * Time.deltaTime);
            }
            if (sol == true)
            {
                transform.position = Vector3.Lerp(transform.position, sol_git, 4f * Time.deltaTime);
            }
        }

        /*
        float newX = 0;
        float touchXDelta = 0;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }
                
        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;         
        newX = Mathf.Clamp(newX, -limitX, limitX);     
        
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + _currentRunningSpeed * Time.deltaTime);           
        transform.position = newPosition;
        */

            if (boosting == true)
            {
                boostTimer += Time.deltaTime;
                if (boostTimer >= 1.7f)
                {
                    speed = 14;
                    boostTimer = 0;
                    boosting = false;
                }
           }
}
    public void ChangeSpeed(float value)
    {
        _currentRunningSpeed = value;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "apple")
        {
            particle.transform.position = gameObject.transform.position;
            particle.Play();
            boosting = true;
            speed = 20;
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
