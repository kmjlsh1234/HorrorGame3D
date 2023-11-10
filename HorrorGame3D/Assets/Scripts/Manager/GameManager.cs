using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Assets.Scripts.Common;
using Assets.Scripts.Manager.Base;

namespace Assets.Scripts.Manager
{
    public class GameManager : SingletonBase<GameManager>
    {
        private List<PlayerData> PlayerDataList;
        public PlayerData _curPlayerData;
        public GameObject Player;
        private const string UserCode = "UserData";

        public void Init()
        {
            Player = GameObject.FindWithTag("Player");
        }
        public void SaveUserData(int slotNum)
        {
            PlayerDataList[slotNum].PlayerPosition = Player.transform.position;
            PlayerDataList[slotNum].PlayerRotation = Player.transform.rotation;
            PlayerDataList[slotNum].QuestName = _curPlayerData.QuestName;
            PlayerDataList[slotNum].ItemList = _curPlayerData.ItemList;
            PlayerDataList[slotNum].DateTime = DateTime.Now.ToString(("yyyy-MM-dd HH:mm:ss tt"));
            try
            {
                ES3.Save<List<PlayerData>>(UserCode, PlayerDataList);
                Debug.Log("데이터 저장 완료!");
            }
            catch(Exception ex)
            {
                Debug.LogError($"데이터 저장 실패..\n{ex}");
            }
        }

        public void LoadUserData(int slotNum)
        {
            try
            {
                PlayerDataList = ES3.Load<List<PlayerData>>(UserCode, defaultValue: new List<PlayerData>());
                _curPlayerData = PlayerDataList[slotNum];
                Debug.Log("데이터 불러오기 성공!");
            }
            catch(Exception ex)
            {
                Debug.LogError($"데이터 로드 실패..\n{ex}");
            }
            
        }
        
        public PlayerData GetPlayerData(int slotNum)
        {
            return PlayerDataList[slotNum];
        }

        public void AddItem(string item)
        {
            _curPlayerData.ItemList.Add(item);
            Debug.Log($"{item} 추가 완료");
        }

        public bool UseItem(string item)
        {
            string targetItem = _curPlayerData.ItemList.FirstOrDefault(x => x == item);

            if (targetItem != null)
            {
                _curPlayerData.ItemList.Remove(targetItem);
                Debug.Log($"{targetItem} 사용");
                return true;
            }
            else
            {
                Debug.Log("Item Not Found!!");
                return false;
            }
        }
    }
}

