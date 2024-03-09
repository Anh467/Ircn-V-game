using Assets.Inventory;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class shopItems : MonoBehaviour
{
    public static shopItems Instance;
    [SerializeField]
    List<GameObject> Items;
    [SerializeField]
    TextMeshProUGUI status;
    [SerializeField]
    TextMeshProUGUI price;
    bool Shop = false;
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

    }

    public int? PriceSell(CollectableType type)
    {
        //chọn sau
        var Item = Items.FirstOrDefault(x =>
        {
            Collectable collectable = x.GetComponent<Collectable>();
            return collectable.type == type;
        });
        if (Item != null)
        {
            Collectable collectable = Item.GetComponent<Collectable>();
            price.text = collectable.price.ToString();
            return collectable.price;
        }
        price.text = "null";
        return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Shop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Shop = false;
        }
    }
    public bool NearShop()
    {
        return Shop;
    }
    public void SetPrice(int itemPrice, string itemStatus)
    {
        price.text = itemPrice.ToString();
        status.text = itemStatus;
    }
}
