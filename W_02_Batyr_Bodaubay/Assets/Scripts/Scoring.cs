using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Score_txt;
    int g1_scr=0, g2_scr=0;
    // Start is called before the first frame update
    public void Goal(string goal){
        if(goal == "Goal1") g1_scr++;
        if(goal == "Goal2") g2_scr++;
        Score_txt.text = "Score: " + g1_scr + " : " + g2_scr;
    }
}
