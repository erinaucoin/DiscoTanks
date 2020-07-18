using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    public  HighscoreAsset m_highscores;
    public InputField m_playerNameField;

    public void startGame()
    {
        //if (m_highscores.m_players == null)
        //    m_highscores.m_players = new Dictionary<string, int>();

        if (!m_highscores.m_players.ContainsKey(m_playerNameField.text))
        {
            m_highscores.m_players.Add(m_playerNameField.text, 0);
        }

        m_highscores.playerName = m_playerNameField.text;
        SceneManager.LoadScene(1);
    }

    public void exit()
    {
        Application.Quit();
    }
}
