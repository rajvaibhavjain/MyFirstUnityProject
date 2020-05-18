using System;
using TMPro;
using UnityEngine;

namespace DapperDino.Scoreboards {

    [Serializable]
    public class ScoreboardEntryUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI entryNameText = null;
        [SerializeField] private TextMeshProUGUI entryScoreText = null;
        // Start is called before the first frame update
        public void Initialise(ScoreboardEntryData scoreboardEntryData) 
        {
            entryNameText.text = scoreboardEntryData.entryName;
            entryScoreText.text = scoreboardEntryData.entryScore.ToString();
        }
    }

}

