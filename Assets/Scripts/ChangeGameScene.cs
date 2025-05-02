//ボタンを押したらシーンを切り替えるスクリプト
using CI.QuickSave;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeGameScene : MonoBehaviour
{
    public static int playerNum;//ログインしたプレイヤーの番号管理
    public static int deleteNum;//削除ボタンを押したplayerの番号管理

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //LoadSceneのOKボタンを押す関数
    public void OKButton()
    {
        //本編シーンの呼び出し
        SceneManager.LoadScene("GameScene");
    }
    public void GoDataSelectButton()
    {
        //データ選択シーンの呼び出し
        SceneManager.LoadScene("DataSelectScene");
    }

    //プレイヤー1のボタンを押したときの関数
    public void Player1Button()
    {
        
        string player1FilePath = Path.Combine(QuickSaveGlobalSettings.StorageLocation, "QuickSave", "Player1NameInputs.json");

        //探したいファイルがあればシーンの呼び出し
        if (File.Exists(player1FilePath))
        {
            //dataがあれば本編へ
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            //無ければLoadSceneへ
            SceneManager.LoadScene("LoadScene");
        }
        playerNum = 1;
        Debug.Log("Player1がログインしました");

    }
    public void Player2Button()
    {

        string player2FilePath = Path.Combine(QuickSaveGlobalSettings.StorageLocation, "QuickSave", "Player2NameInputs.json");

        //探したいファイルがあればシーンの呼び出し
        if (File.Exists(player2FilePath))
        {
            //dataがあれば本編へ
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            //無ければLoadSceneへ
            SceneManager.LoadScene("LoadScene");


        }
        playerNum = 2;
        Debug.Log("Player2がログインしました");

    }
    public void Player3Button()
    {
        string player3FilePath = Path.Combine(QuickSaveGlobalSettings.StorageLocation, "QuickSave", "Player3NameInputs.json");

        //探したいファイルがあればシーンの呼び出し
        if (File.Exists(player3FilePath))
        {
            //dataがあれば本編へ
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            //無ければLoadSceneへ
            SceneManager.LoadScene("LoadScene");


        }
        playerNum = 3;
        Debug.Log("Player3がログインしました");

    }
    

}
