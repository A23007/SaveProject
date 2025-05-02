using System.IO;
using CI.QuickSave;
using UnityEngine;
using UnityEngine.UI;


public class Player1SaveManager : MonoBehaviour
{
    public InputField playerName;//Playerの名前
  


    private void Awake()
    {
        // 保存先を任意のパスにしたい場合ここで設定（例：デスクトップ）
         QuickSaveGlobalSettings.StorageLocation = "C:/Users/A23007/Desktop/Group/MyProject/Assets/PlayerData";
    }

    public void Save()
    {
        switch(ChangeGameScene.playerNum)
        {
            case 1:
                //入力したデータをjsonに保存する
                QuickSaveWriter.Create("Player1NameInputs")
                               .Write("PlayerName1", playerName.text)
                               .Commit();

                Debug.Log("Player1のデータを保存します");

            break;

            case 2:
                //入力したデータをjsonに保存する
                QuickSaveWriter.Create("Player2NameInputs")
                               .Write("PlayerName2", playerName.text)
                               .Commit();

                Debug.Log("Player2のデータを保存します");
            break;

            case 3:
                //入力したデータをjsonに保存する
                QuickSaveWriter.Create("Player3NameInputs")
                               .Write("PlayerName3", playerName.text)
                               .Commit();

                Debug.Log("Player3のデータを保存します");

                break;
        }
  

    }

    public void Load()
    {
        switch(ChangeGameScene.playerNum)
        {
            case 1:
                //探したいファイルのパスと名前
                string Player1FilePath = Path.Combine(QuickSaveGlobalSettings.StorageLocation, "QuickSave", "Player1NameInputs.json");

                //探したいファイルのがあるかどうか
                if (File.Exists(Player1FilePath))
                {
                    //あるなら呼び出す
                    QuickSaveReader.Create("Player1NameInputs").Read<string>("PlayerName1", (r) => { playerName.text = r; });//ここ変えたよ
                }
                else
                {
                    Debug.Log("最初のシーンでないか、セーブデータが存在しません：" + Player1FilePath);
                }
                break;

            case 2:
                string Player2FilePath = Path.Combine(QuickSaveGlobalSettings.StorageLocation, "QuickSave", "Player2NameInputs.json");

                //探したいファイルのがあるかどうか
                if (File.Exists(Player2FilePath))
                {
                    //あるなら呼び出す
                    QuickSaveReader.Create("Player2NameInputs").Read<string>("PlayerName2", (r) => { playerName.text = r; });//ここ変えたよ
                }
                else
                {
                    Debug.Log("最初のシーンでないか、セーブデータが存在しません：" + Player2FilePath);
                }
            break;

            case 3:
                //探したいファイルのパスと名前
                string Player3FilePath = Path.Combine(QuickSaveGlobalSettings.StorageLocation, "QuickSave", "Player3NameInputs.json");

                //探したいファイルのがあるかどうか
                if (File.Exists(Player3FilePath))
                {
                    //あるなら呼び出す
                    QuickSaveReader.Create("Player3NameInputs").Read<string>("PlayerName3", (r) => { playerName.text = r; });//ここ変えたよ
                }
                else
                {
                    Debug.Log("最初のシーンでないか、セーブデータが存在しません：" + Player3FilePath);
                }
            break;
            
        }
        
    }


    void Start()
    {
        //関数よびだし
        Load();
    }
}
