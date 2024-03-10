using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopActions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && gameObject.tag == "sellShop")
        {
            shopItems.Instance.SetNearShop(true);
        }
        if (collision.gameObject.tag == "player" && gameObject.tag == "buyShop")
        {
            shopItems.Instance.SetNearShop2(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && gameObject.tag == "sellShop")
        {
            shopItems.Instance.SetNearShop(false);
        }
        if (collision.gameObject.tag == "player" && gameObject.tag == "buyShop")
        {
            shopItems.Instance.SetNearShop2(false);
        }
    }
}
