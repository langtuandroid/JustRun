using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coin : MonoBehaviour
{
    [SerializeField] AudioClip _Clip;
    [SerializeField] ParticleSystem Particle;

    public void Start()
    {
        Particle.Stop();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Particle.transform.position = gameObject.transform.position;
            Particle.Play();
            Destroy(gameObject);
            CoinText.coinAmount += 5;
            SoundManager.Instance.PlaySound(_Clip);       
        }
    }
}
