//dataSelectSceneのみで使うスクリプト
using UnityEngine;
using CI.QuickSave;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DataSelectSceneManager : MonoBehaviour
{
    public Button Player1Button;//プレイヤー1ボタン
    public Button Player2Button;//プレイヤー2ボタン
    public Button Player3Button;//プレイヤー3ボタン

    void Start()
    {
        // Player1の保存先パスを組み立て
        string player1FilePath = Path.Combine(QuickSaveGlobalSettings.StorageLocation, "QuickSave", "Player1NameInputs.json");
         // Player2の保存先パスを組み立て
        string player2FilePath = Path.Combine(QuickSaveGlobalSettings.StorageLocation, "QuickSave", "Player2NameInputs.json");
        // Player2の保存先パスを組み立て
        string player3FilePath = Path.Combine(QuickSaveGlobalSettings.StorageLocation, "QuickSave", "Player3NameInputs.json");

        // セーブデータが存在する場合
        if (File.Exists(player1FilePath))
        {
            QuickSaveReader.Create("Player1NameInputs").Read<string>("PlayerName1", (playerName) =>
            {
                // ボタンのテキストを変更
                TextMeshProUGUI btnText = Player1Button.GetComponentInChildren<TextMeshProUGUI>();
                if (btnText != null)
                {
                    btnText.text = playerName;
                }
                else
                {
                    Debug.Log("ボタン内にTextコンポーネントが見つかりませんでした");
                }
            });
        }
        else
        {
            Debug.Log("セーブファイルが見つかりません：" + player1FilePath);
        }

            

        // Player2のセーブデータが存在する場合
        if (File.Exists(player2FilePath))
        {
            QuickSaveReader.Create("Player2NameInputs").Read<string>("PlayerName2", (playerName) =>
            {

                 // ボタンのテキストを変更
                 TextMeshProUGUI btnText = Player2Button.GetComponentInChildren<TextMeshProUGUI>();
                 if (btnText != null)
                 {
                    btnText.text = playerName;
                 }
                 else
                 {
                    Debug.Log("ボタン内にTextコンポーネントが見つかりませんでした");
                 }
            });
        }
        else
        {
            Debug.Log("セーブファイルが見つかりません：" + player2FilePath);
        }

        // セーブデータが存在する場合
        if (File.Exists(player3FilePath))
        {
            QuickSaveReader.Create("Player3NameInputs").Read<string>("PlayerName3", (playerName) =>
            {
                // ボタンのテキストを変更
                TextMeshProUGUI btnText = Player3Button.GetComponentInChildren<TextMeshProUGUI>();
                if (btnText != null)
                {
                    btnText.text = playerName;
                }
                else
                {
                    Debug.Log("ボタン内にTextコンポーネントが見つかりませんでした");
                }
            });
        }
        else
        {
            Debug.Log("セーブファイルが見つかりません：" + player1FilePath);
        }

    }
}