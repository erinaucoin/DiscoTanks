using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HighscoresOutput : MonoBehaviour {

    public HighscoreAsset m_highscoreAsset;
    public Text m_highscoresOutput;

    private void Start()
    {
        if (m_highscoreAsset.m_players == null)
            return;

        string results = "";

        var temp = m_highscoreAsset.m_players.OrderByDescending(x => x.Value).ToList();
        for(int i = 0; i < 3 && i < temp.Count; ++i)
        {
            results += temp[i].Key + ": " + temp[i].Value + "\n";
        }

        m_highscoresOutput.text = results;
    }

}
