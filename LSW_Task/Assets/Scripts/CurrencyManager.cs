using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager sharedInstance;
    [SerializeField] TMP_Text dollarsUI;
    public int dollars  = 500;

    private void Start()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        dollarsUI.text = dollars.ToString();
    }
}
