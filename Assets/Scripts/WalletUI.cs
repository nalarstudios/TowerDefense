using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletUI : MonoBehaviour
{
    GameObject wallet;
    // Start is called before the first frame update
    void Start()
    {
        wallet = GameObject.FindWithTag("Wallet");
        if (wallet == null)
        {
            Debug.LogError("You forgot wallet you Dingus!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Wallet walletComponent = wallet.GetComponent<Wallet>();
        GetComponent<Text>().text = walletComponent.currency.ToString();
    }
}
