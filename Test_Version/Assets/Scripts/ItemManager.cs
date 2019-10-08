using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<GameObject> _Item;
    public PlayerController playerController;

    // 무기 활성화
    public void WeaponOpen(int itemNumber)
    {
        WeaponClose();
        _Item[itemNumber].gameObject.SetActive(true);
        Debug.Log(_Item[itemNumber]);
        playerController._weapon = _Item[itemNumber];
    }
    
    public void WeaponClose()
    {
        for (int x = 0; x < _Item.Count; x++)
        {
            _Item[x].gameObject.SetActive(false);
        }
    }
}
