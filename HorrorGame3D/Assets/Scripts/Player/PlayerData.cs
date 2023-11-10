using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Assets.Scripts.Common;
public class PlayerData
{
    public Vector3 PlayerPosition;
    public Quaternion PlayerRotation;
    public QuestName QuestName;
    public List<string> ItemList;
    public string DateTime;
    public bool CheckItem(string item)
    {
        string targetItem = ItemList.FirstOrDefault(x => x == item);
        
        if (targetItem != null)
        {
            Debug.Log($"{targetItem} »ç¿ë");
            ItemList.Remove(targetItem);
            return true;
        } 
        else
        {
            Debug.Log("Item Not Found!!");
            return false;
        }
            
    }

    
}
