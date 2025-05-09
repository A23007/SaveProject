using CI.QuickSave;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGameScene : MonoBehaviour
{
    public static int playerNum;   // ログインしたプレイヤー番号の管理
    public static int deleteNum;   // 削除したいプレイヤー番号の管理（別スクリプトで使用）

    // 本編シーンへ進むボタン（LoadSceneのOKボタン）
    public void OKButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    // データ選択シーンへ戻るボタン
    public void GoDataSelectButton()
    {
        SceneManager.LoadScene("DataSelectScene");
    }

    // プレイヤー1〜3の選択ボタン
    public void Player1Button() => HandlePlayerButton(1);
    public void Player2Button() => HandlePlayerButton(2);
    public void Player3Button() => HandlePlayerButton(3);

    // プレイヤー選択処理を共通化
    private void HandlePlayerButton(int playerIndex)
    {
        string fileName = $"Player{playerIndex}NameInputs.json";
        string filePath = Path.Combine(QuickSaveGlobalSettings.StorageLocation, "QuickSave", fileName);

        // プレイヤー番号を記録
        playerNum = playerIndex;

        // セーブデータがあるか確認してシーン遷移
        if (File.Exists(filePath))
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            SceneManager.LoadScene("LoadScene");
        }

        Debug.Log($"Player{playerIndex} がログインしました");
    }
}
