using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; 

public class Inventory : MonoBehaviour
{

    public Transform rootSlot;

    private List<Slot> slots;

    public Store store;

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<Slot>();

        int slotCnt = rootSlot.childCount;

        for (int i = 0; i < slotCnt; i++)
        {
            var slot = rootSlot.GetChild(i).GetComponent<Slot>();

            slots.Add(slot);
        }
        store.onSlotClick += BuyItem;
         
    }

    void BuyItem(ItemProperty item) //아이템 구입
    {
        itemequip ie = gameObject.AddComponent<itemequip>();

        Debug.Log(item.name);
        Debug.Log(item.categories);
        ie.UserPreferenceCalculate("clientid", "james", item.name, item.categories, "buy");
        var emptySlot = slots.Find(t =>
        {
            return t.item == null || t.item.name == string.Empty;
        });
        if (emptySlot != null)
        {
            emptySlot.SetItem(item);
        }

    }
}
