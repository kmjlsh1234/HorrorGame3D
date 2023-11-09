using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerData : MonoBehaviour
{
    public Vector3 _position;
    public Vector3 _rotation;
    public int _questNum;
    public List<string> _itemList;

    public bool CheckItem(string item)
    {
        string targetItem = _itemList.FirstOrDefault(x => x == item);
        
        if (targetItem != null)
        {
            Debug.Log($"{targetItem} 사용");
            _itemList.Remove(targetItem);
            return true;
        } 
        else
        {
            Debug.Log("Item Not Found!!");
            return false;
        }
            
    }

    public void AddItem(string item)
    {
        Debug.Log($"{item} 추가 완료");
        _itemList.Add(item);
    }
}
