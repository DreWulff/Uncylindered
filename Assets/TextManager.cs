using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI stamina;
    public TextMeshProUGUI time;
    private Manager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText("Score: " + manager.score.ToString());
        stamina.SetText("Stamina: " + ((int)manager.stamina).ToString());
        time.SetText("Time: " + ((int)manager.time).ToString());
    }
}
