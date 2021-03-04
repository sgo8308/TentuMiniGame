using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [HideInInspector]
    public ItemProperty item;
    public UnityEngine.UI.Image image;
    public UnityEngine.UI.Button sellBtn;
    public UnityEngine.UI.Text itemname;
    public UnityEngine.UI.Text price;

    private void Awake()
    {
        image.enabled = false;
        SetSellBtnInteractable(false);
    }

    void SetSellBtnInteractable(bool b) 
    {
        if (sellBtn != null)
            sellBtn.interactable = b;
    }
    public void SetItem(ItemProperty item)//상점 아이템 셋팅.
    {
        this.item = item;

        if (item == null)
        {
            image.enabled = false;
            SetSellBtnInteractable(false);
            gameObject.name = "Empty";
            itemname.text = "Empty";
            price.text = "Empty".ToString();
        }
        else
        {
            SetSellBtnInteractable(true);
            image.enabled = true;
            gameObject.name = item.name;
            image.sprite = item.sprite;
            itemname.text = item.itemname;
            price.text = item.price.ToString();
        }
    }

    public void OnClickSellBtn()
    {
        SetItem(null);
    }
}
