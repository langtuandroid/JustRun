using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinText : MonoBehaviour
{
    public Text cointext;
    public static int coinAmount;
    // Start is called before the first frame update
    void Start()
    {
        cointext = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        cointext.text = coinAmount.ToString();
    }
}
