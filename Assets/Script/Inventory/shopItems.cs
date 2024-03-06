using Assets.Inventory;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class shopItems : MonoBehaviour
{
    public static shopItems Instance;
    [SerializeField]
    List<GameObject> Items;
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

    public int? Sell(CollectableType type)
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
            return collectable.price;
        }
        return null;
    }
}
