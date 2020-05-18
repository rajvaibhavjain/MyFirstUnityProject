using System.IO;

using UnityEngine;

namespace DapperDino.Scoreboards {
    
    public class Scoreboard : MonoBehaviour
    {

        [SerializeField] private int maxScoreboardEntries = 5;
        [SerializeField] private Transform highscoreHolderTransform = null;
        [SerializeField] private GameObject scoreboardEndObject = null;

        [Header("Test")]
        [SerializeField] ScoreboardEntryData testEntryData = new ScoreboardEntryData();



        // Start is called before the first frame update
    }

}






