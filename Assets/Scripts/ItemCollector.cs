using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] AudioSource colectCoinsfx;
    int coinCounter = 0;
    [SerializeField] Text coinsText;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Coin"))
        {
            Destroy(collider.gameObject);
            coinCounter++;
            colectCoinsfx.Play();
            coinsText.text = "Coins: " + coinCounter.ToString();
        }
    }
}
