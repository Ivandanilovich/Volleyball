using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private List<Text> texts;

    public void UpdateUI(int playerID, int points)
    {
        texts[playerID].text = points.ToString();
        if (points >= 10)
        {
            MyNetworkManager.winner = "player " + playerID + " win";
            SceneManager.LoadScene("EndGame");
        }
    }
}
