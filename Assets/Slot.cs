using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slot : MonoBehaviour
{
    [HideInInspector]
    public ItemProperty item;
    public Inventory inven;
    public UnityEngine.UI.Image image;
    public UnityEngine.UI.Button sellBtn;
    public UnityEngine.UI.Text itemname;
    public UnityEngine.UI.Text price;
    public UnityEngine.UI.Image head;
    public UnityEngine.UI.Image body;
    public UnityEngine.UI.Image bottom;
    public UnityEngine.UI.Image shoes;
    public UnityEngine.UI.Image equipCheck;
    public UnityEngine.UI.Text log_text;
    public UnityEngine.UI.ScrollRect scrollRect;

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
                if (equipCheck.gameObject.activeSelf == true)
                {
                    equipCheck.gameObject.SetActive(false);
                    log_text.text += item.itemname + "의상을 탈의 했습니다.\n";
                    scrollRect.verticalNormalizedPosition = 0.0f;
                    head.sprite = null;
                }
                else if (equipCheck.gameObject.activeSelf == false && head.sprite != null) 
                {
                    log_text.text += "다른 의상을 입고있어 착용이 불가능 합니다.\n";
                    scrollRect.verticalNormalizedPosition = 0.0f;
                }
                else
                {
                    head.sprite = item.sprite;
                    equipCheck.gameObject.SetActive(true);
                    log_text.text += item.itemname + " 의상을 착용합니다.\n";
                    scrollRect.verticalNormalizedPosition = 0.0f;
                }
                break;
            case "body":
                if (equipCheck.gameObject.activeSelf == true)
                {
                    equipCheck.gameObject.SetActive(false);
                    log_text.text += item.itemname + "의상을 탈의 했습니다.\n";
                    scrollRect.verticalNormalizedPosition = 0.0f;
                    body.sprite = null;
                } else if (equipCheck.gameObject.activeSelf == false && body.sprite != null) 
                {
                    log_text.text += "다른 의상을 입고있어 착용이 불가능 합니다.\n";
                    scrollRect.verticalNormalizedPosition = 0.0f;
                }
                else
                {
                    body.sprite = item.sprite;
                    equipCheck.gameObject.SetActive(true);
                    log_text.text += item.itemname + " 의상을 착용합니다.\n";
                    scrollRect.verticalNormalizedPosition = 0.0f;
                }
                break;
            case "bottom":
                if (equipCheck.gameObject.activeSelf == true)
                {
                    equipCheck.gameObject.SetActive(false);
                    log_text.text += item.itemname + "의상을 탈의 했습니다.\n";
                    scrollRect.verticalNormalizedPosition = 0.0f;
                    bottom.sprite = null;
                }
                else if (equipCheck.gameObject.activeSelf == false && bottom.sprite != null)
                {
                    log_text.text += "다른 의상을 입고있어 착용이 불가능 합니다.\n";
                    scrollRect.verticalNormalizedPosition = 0.0f;
                }
                else
                {
                    bottom.sprite = item.sprite;
                    equipCheck.gameObject.SetActive(true);
                    log_text.text += item.itemname + " 의상을 착용합니다.\n";
                    scrollRect.verticalNormalizedPosition = 0.0f;
                }
                break;
            case "shoes":
                if (equipCheck.gameObject.activeSelf == true)
                {
                    equipCheck.gameObject.SetActive(false);
                    log_text.text += item.itemname + "의상을 탈의 했습니다.\n";
                    scrollRect.verticalNormalizedPosition = 0.0f;
                    shoes.sprite = null;
                }
                else if (equipCheck.gameObject.activeSelf == false && shoes.sprite != null) 
                {
                    log_text.text += "다른 의상을 입고있어 착용이 불가능 합니다.\n";
                    scrollRect.verticalNormalizedPosition = 0.0f;
                }
                else
                {
                    shoes.sprite = item.sprite;
                    equipCheck.gameObject.SetActive(true);
                    log_text.text += item.itemname + " 의상을 착용합니다.\n";
                    scrollRect.verticalNormalizedPosition = 0.0f;
                }
                break;
        }
    }
}
