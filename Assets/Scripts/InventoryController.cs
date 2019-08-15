using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    private int inventory;
    public GameObject player;
    private Text inventoryText;

    // Start is called before the first frame update
    void Start()
    {
        inventoryText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        inventory = player.GetComponent<CharacterScript>().getInventory();
        inventoryText.text = inventory.ToString();
    }
}
