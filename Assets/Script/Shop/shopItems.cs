using Assets.Inventory;
using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class shopItems : MonoBehaviour
{
    public static shopItems Instance;
    [SerializeField]
    List<GameObject> SellItems;
    [SerializeField]
    List<GameObject> BuyItems;
    [SerializeField]
    TextMeshProUGUI status;
    [SerializeField]
    TextMeshProUGUI price;
    [SerializeField]
    TextMeshProUGUI LevelText;
    bool Shop = false;
    bool Shop2A = false;
    int Level = 1;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LevelText.text = Level.ToString();
    }
    public int? BuyPriceOnShop(CollectableType type)
    {
        var Item = BuyItems.FirstOrDefault(x =>
        {
            Collectable collectable = x.GetComponent<Collectable>();
            return collectable.type == type;
        });
        if (Item != null)
        {
            Collectable collectable = Item.GetComponent<Collectable>();
            SetPrice(collectable.price, "Thong tin san pham");
            return collectable.price;
        }
        SetPrice(null, "Thong tin san pham");
        return null;
    }
    public int? SellPriceOnShop(CollectableType type)
    {
        var Item = SellItems.FirstOrDefault(x =>
        {
            Collectable collectable = x.GetComponent<Collectable>();
            return collectable.type == type;
        });
        if (Item != null)
        {
            Collectable collectable = Item.GetComponent<Collectable>();
            SetPrice(collectable.price, "Thong tin san pham");
            return collectable.price;
        }
        SetPrice(null, "Thong tin san pham");
        return null;
    }

    public bool NearShop()
    {
        return Shop;
    }
    public bool NearShop2()
    {
        return Shop2A;
    }
    public void SetNearShop(bool shop)
    {
        Shop = shop;
    }
    public void SetNearShop2(bool shop)
    {
        Shop2A = shop;
    }
    public void SetPrice(int? itemPrice, string itemStatus)
    {
        price.text = itemPrice!=null ? itemPrice.ToString() : "NULL";
        status.text = itemStatus;
    }
    public List<GameObject> GetBuyShopItems()
    {
        return BuyItems;
    }

    public void IncLevel()
    {
        Level++;
    }
    public int GetLevel()
    {
        return Level;
    }
}
