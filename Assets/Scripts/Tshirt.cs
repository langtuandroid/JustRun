using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tshirt : MonoBehaviour
{

    public Material material;
    public Material material2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Destroy(gameObject);
            CoinText.coinAmount -= 15;
            material.color = material2.color;
        }
    }
}
