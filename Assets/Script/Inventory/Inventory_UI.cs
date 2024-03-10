using Assets.Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject shopSellInventory;
    public static Inventory_UI instance;
    public List<Slot_UI> slots_UI;

    [SerializeField]
    public player playerr;
    private void Awake()
    {
        //slots_UI = new List<Slot_UI>(playerr.inventory.items.Count);
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel.SetActive(false);
        /*for (int i = 0; i < playerr.inventory.items.Count; i++)
        {
            slots_UI.Add(new Slot_UI());
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory(inventoryPanel, shopSellInventory, shopItems.Instance.NearShop() || shopItems.Instance.NearShop2());
        }
        if (shopItems.Instance.NearShop2())
        {
            SetUpShop();
        }
        else
        {
            SetUp();
        }
    }
    public void selectItem(int index)
    {
        slots_UI[index].SetBackGroundColor(Color.green);
    }
    public void unSelectItem(int index)
    {
        slots_UI[index].SetBackGroundColor(new Color(190 / 255f, 176 / 255f, 176 / 255f));
    }
    public void ToggleInventory(GameObject inventory, GameObject shop, bool isShop)
    {
        if (!inventory.activeSelf || (!shop.activeSelf && isShop))
        {
            Time.timeScale = 0;
            inventory.SetActive(true);
            if (isShop)
            {
                shop.SetActive(true);
            }
        }
        else
        {
            Time.timeScale = 1;
            inventory.SetActive(false);
            shop.SetActive(false);
        }
    }
    public void SetUp()
    {
        if (slots_UI.Count == playerr.inventory.items.Count)
        {
            for (int i = 0; i < slots_UI.Count; i++)
            {
                if (playerr.inventory.items[i].type != CollectableType.NONE)
                {
                    slots_UI[i].SetItem(playerr.inventory.items[i]);
                }
                else
                {
                    slots_UI[i].SetEmpty();
                }
            }
        }

    }
    private void SetUpShop()
    {
        var buyItems = shopItems.Instance.GetBuyShopItems();
        for (int i = 0; i < buyItems.Count; i++)
        {
            Collectable collectable = buyItems[i].GetComponent<Collectable>();
            slots_UI[i].SetItem(collectable.GetItem());
        }
    }
}
