//Playerデータの削除プログラム
using UnityEngine;
using CI.QuickSave;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class DeleteDataScript : MonoBehaviour
{
    public static int deleteNum;//消したいPlayerの管理
    [SerializeField] private GameObject deleteConfirmation;//削除確認画面
    [SerializeField] private TextMeshProUGUI deletePlayerName;//削除したいPlayerの名前の管理
    [SerializeField] private TextMeshProUGUI player1ButtonText;
    [SerializeField] private TextMeshProUGUI player2ButtonText;
    [SerializeField] private TextMeshProUGUI player3ButtonText;


    void Start()
    {
        deleteConfirmation.SetActive(false);
    }

   // void Update()
   // {
        
   // }

    //Player1の削除ボタン
    public void DeletePlayer1Button()
    {
        deleteNum = 1;
       deleteConfirmation.SetActive(true);//削除確認画面の表示
        Debug.Log("player1の削除ボタンが押されました");

        // Player1の保存先パスを組み立て
        string player1FilePath = Path.Combine(QuickSaveGlobalSettings.StorageLocation, "QuickSave", "Player1NameInputs.json");

        // セーブデータが存在する場合
        if (File.Exists(player1FilePath))
        {
            QuickSaveReader.Create("Player1NameInputs").Read<string>("PlayerName1", (playerName) =>
            {

                deletePlayerName.text = "「" + playerName + "」";

            });
        }
        else
        {
            Debug.Log("セーブファイルが見つかりません：" + player1FilePath);
        }

    }
public void DeletePlayer2Button()
    {
        deleteNum = 2;
        deleteConfirmation.SetActive(true);//削除確認画面の表示
        // Player2の保存先パスを組み立て
        string player2FilePath = Path.Combine(QuickSaveGlobalSettings.StorageLocation, "QuickSave", "Player2NameInputs.json");
        // セーブデータが存在する場合
        if (File.Exists(player2FilePath))
        {
            QuickSaveReader.Create("Player2NameInputs").Read<string>("PlayerName2", (playerName) =>
            {

                deletePlayerName.text = "「" + playerName + "」";

            });
        }
        else
        {
            Debug.Log("セーブファイルが見つかりません：" + player2FilePath);
        }

    }
    public void DeletePlayer3Button()
    {
        deleteNum = 3;
        deleteConfirmation.SetActive(true);//削除確認画面の表示
        // Player2の保存先パスを組み立て
        string player3FilePath = Path.Combine(QuickSaveGlobalSettings.StorageLocation, "QuickSave", "Player3NameInputs.json");

        // セーブデータが存在する場合
        if (File.Exists(player3FilePath))
        {
            QuickSaveReader.Create("Player3NameInputs").Read<string>("PlayerName3", (playerName) =>
            {

                deletePlayerName.text = "「" + playerName + "」";

            });
        }
        else
        {
            Debug.Log("セーブファイルが見つかりません：" + player3FilePath);
        }
    }

    //同意ボタン
    public void AgreementButton()
    {

        Debug.Log("AgreementButtonが呼ばれました");
        string fileName = "";
        string keyName = "";

        switch (deleteNum)
        {
            case 1:
                fileName = "Player1NameInputs";
                keyName = "PlayerName1";
                break;
            case 2:
                fileName = "Player2NameInputs";
                keyName = "PlayerName2";

                break;
            case 3:
                fileName = "Player3NameInputs";
                keyName = "PlayerName3";
                break;
            default:
                Debug.LogError("無効な deleteNum: " + deleteNum);
                return;
        }

        // データ削除
        QuickSaveWriter.Create(fileName).Delete(keyName);
        string filePath = Path.Combine(QuickSaveGlobalSettings.StorageLocation, "QuickSave", fileName + ".json");

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log($"{fileName} のファイルを削除しました。");
        }
        Debug.Log("消したいPlayer" +deleteNum);
        // ボタンのテキストを更新
        switch (deleteNum)
        {
            case 1:
                player1ButtonText.text = "新しくはじめる";
                break;
            case 2:
                player2ButtonText.text = "新しくはじめる";
                break;
            case 3:
                player3ButtonText.text = "新しくはじめる";
                break;
             default:
                Debug.Log("データがないよ");
             break;
        }

        deleteConfirmation.SetActive(false);

        
        deleteNum = 0;
    }
    //拒否ボタン
    public void DisafreementButton()
    {
        //削除確認画面を非アクティブに
        deleteConfirmation.SetActive(false);
        Debug.Log("いいえボタンが押されました");
    }
}
