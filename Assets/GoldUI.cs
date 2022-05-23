using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoldUI : MonoBehaviour
{
    Transform Panel;
    Sequence GoldAnimation;
    public Rigidbody rgb;
    void Start()
    {
        AnimationHýzlandýrma();
    }

    public void AnimationHýzlandýrma()
    {
        Panel = GameObject.FindGameObjectWithTag("GoldPanel").transform;
        GoldAnimation = DOTween.Sequence();
        GoldAnimation.Append(transform.DOMove(Panel.position, 2).SetEase(Ease.OutSine)).OnComplete(() => Destroy(gameObject));
    }

}
