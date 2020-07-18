using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HighscoreAsset : ScriptableObject {

    public Dictionary<string, int> m_players = new Dictionary<string, int>();

    public string playerName;

    public int[] playerScores;
}
