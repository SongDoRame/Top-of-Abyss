using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int[] _itemKind = new int[8]; // 0 = 장검, 1 = 양손도끼, 2 = 창, 3 = 해머, 4 = 양손방패, 5 = 한손검, 6 = 한손도끼, 7 = 한손방패

    internal ItemManager IM;

    void Start()
    {
        for (int weaponNumber = 0 ; weaponNumber < _itemKind.Length ; weaponNumber++)
        {
            _itemKind[weaponNumber] = weaponNumber;
        }
        IM = gameObject.GetComponent<ItemManager>();
        IM.WeaponClose();
    }

    void Update()
    {
        
    }
    public void LongSword()
    {
        IM.WeaponOpen(_itemKind[0]);
        Debug.Log("LongSword");
    }
    public void LongAxe()
    {
        IM.WeaponOpen(_itemKind[1]);
        Debug.Log("LongAxe");
    }
    public void Spear()
    {
        IM.WeaponOpen(_itemKind[2]);
        Debug.Log("Spear");
    }
    public void Hammer()
    {
        IM.WeaponOpen(_itemKind[3]);
        Debug.Log("Hammer");
    }
    public void BigShilder()
    {
        IM.WeaponOpen(_itemKind[4]);
        Debug.Log("BigShilder");
    }
    public void ShortSword()
    {
        IM.WeaponOpen(_itemKind[5]);
        Debug.Log("ShortSword");
    }
    public void ShortAxe()
    {
        IM.WeaponOpen(_itemKind[6]);
        Debug.Log("ShortAxe");
    }
    public void SmallShilder()
    {
        IM.WeaponOpen(_itemKind[7]);
        Debug.Log("SmallShilder");
    }

}
