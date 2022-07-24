using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataController : MonoBehaviour
{
    static GameObject _containter;
    static GameObject Container {
        get {
            return _containter;
        }
    }

    static DataController _instance;
    public static DataController Instance {
        get {
            if (!_instance) {
                _containter = new GameObject();
                _containter.name = "DataController";
                _instance = _containter.AddComponent(typeof(DataController)) as DataController;
                DontDestroyOnLoad(_containter);
            }

            return _instance;
        }
    }

    public string GameDataFileName = "CrystalValleyData.json";

    public GameData _gameData;
    public GameData gameData {
        get {
            if (_gameData == null) {
                LoadGameData();
                SaveGameData();
            }

            return _gameData;
        }
    }

    private void Start() {
        LoadGameData();
        SaveGameData();
    }

    public void LoadGameData() {
        string filePath = Application.persistentDataPath + GameDataFileName;

        if (File.Exists(filePath)) {
            // print("불러오기 성공");
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);
        }
        else {
            print("새로운 파일 생성");
            _gameData = new GameData();
        }
    }

    public void SaveGameData() {
        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;

        File.WriteAllText(filePath, ToJsonData);

        // print("저장 완료");
    }

    private void OnApplicationQuit() {
        Instance.gameData.EndDate = DateTime.Now.ToString();
        SaveGameData();
    }

    private void OnApplicationPause(bool pause)
    {
        Instance.gameData.EndDate = DateTime.Now.ToString();
        SaveGameData();
    }
}
