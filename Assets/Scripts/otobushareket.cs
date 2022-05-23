using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otobushareket : MonoBehaviour
{
    public float MovemntSpeed;
    public float HorSpeed;

    float hor;

    [SerializeField] ParticleSystem particle;

    [SerializeField] AudioClip _Clip;

    // Start is called before the first frame update
    void Start()
    {
        particle.Play();
        SoundManager.Instance.PlaySound(_Clip);
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(-1 * hor * HorSpeed, 0, -1 * MovemntSpeed * Time.deltaTime));
    }
}
