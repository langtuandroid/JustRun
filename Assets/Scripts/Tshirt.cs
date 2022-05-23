using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tshirt : MonoBehaviour
{
    [SerializeField] AudioClip _Clip; 

    public Material material;
    public Material material2;

    [SerializeField] ParticleSystem particle;

    private void Start()
    {
        particle.Stop();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            particle.transform.position = gameObject.transform.position;
            particle.Play();
            Destroy(gameObject);
            CoinText.coinAmount -= 15;
            SoundManager.Instance.PlaySound(_Clip);
            material.color = material2.color;
        }
    }
}
