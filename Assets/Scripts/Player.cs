using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float boostTimer;
    public bool boosting;

    public Material material;
    public Animator myAnimator;

    [SerializeField] AudioClip _Clip;

    [SerializeField] ParticleSystem particle;

    public float _currentRunningSpeed;
    public float xSpeed;
    public float limitX;

    void Start()
    {
        _currentRunningSpeed = 10f;
        particle.Stop();
        boostTimer = 0;
        boosting = false;
        material.color = Color.red;
}
    void Update()
{     
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

        if (boosting == true)
            {
                boostTimer += Time.deltaTime;
                if (boostTimer >= 1.7f)
                {
                    _currentRunningSpeed = 10f;
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
            _currentRunningSpeed = 20f;
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
