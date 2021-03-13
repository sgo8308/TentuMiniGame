using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slot : MonoBehaviour
{
    [HideInInspector]
    public ItemProperty item;
    public UnityEngine.UI.Image image;
    public UnityEngine.UI.Button sellBtn;
    public UnityEngine.UI.Text itemname;
    public UnityEngine.UI.Text price;
    public UnityEngine.UI.Image head;
    public UnityEngine.UI.Image body;
    public UnityEngine.UI.Image bottom;
    public UnityEngine.UI.Image shoes;
    public UnityEngine.UI.Image equipCheck;
    UnityEngine.UI.Image headeq;
    UnityEngine.UI.Image bodyeq;
    UnityEngine.UI.Image bottomeq;
    UnityEngine.UI.Image shoeseq;

    private void Awake()
    {
        image.enabled = false;
        SetSellBtnInteractable(false);
    }

    void Update()
    {
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

    public void onClickItem()
    {
        Debug.Log(item.name);
        Debug.Log(item.parts);
        itemequip ie = gameObject.AddComponent<itemequip>();
        ie.UserPreferenceCalculate("MINIGAME", "james", item.name, item.categories, "equip");
        switch (item.parts)
        {
            case "head":
                head.sprite = item.sprite;
                Debug.Log(headeq);
                equipCheck.gameObject.SetActive(true);
                break;
            case "body":
                body.sprite = item.sprite;
                Debug.Log(bodyeq);
                equipCheck.gameObject.SetActive(true);
                break;
            case "bottom":
                bottom.sprite = item.sprite;
                Debug.Log(bottomeq);
                equipCheck.gameObject.SetActive(true);
                break;
            case "shoes":
                shoes.sprite = item.sprite;
                Debug.Log(shoeseq);
                equipCheck.gameObject.SetActive(true);
                break;
        }
    }
}
