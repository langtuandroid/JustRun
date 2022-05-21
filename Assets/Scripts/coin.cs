using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coin : MonoBehaviour
{
    [SerializeField] AudioClip _Clip;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Destroy(gameObject);
            CoinText.coinAmount += 5;
            SoundManager.Instance.PlaySound(_Clip);
        }
    }
}
