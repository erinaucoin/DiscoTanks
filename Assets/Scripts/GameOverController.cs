using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

    public TankControler m_player;
    public HighscoreAsset m_highScoreAsset;
    public ScoreController m_scoreController;

    private void Update()
    {
        if (m_player != null)
            return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            int prevScore;
            m_highScoreAsset.m_players.TryGetValue(m_highScoreAsset.playerName, out prevScore);

            if (prevScore < m_scoreController.GetScore())
                m_highScoreAsset.m_players[m_highScoreAsset.playerName] = m_scoreController.GetScore();

            SceneManager.LoadScene(0);
        }
    }
}
