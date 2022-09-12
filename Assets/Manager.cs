using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public float stamina;
    public GameObject treantPrefab;
    public float time = 60f;
    public int score = 0;
    public GameObject inGame;
    public GameObject gameOver;
    public TextMeshProUGUI finalScore;
    private float xPos;
    private float yPos;
    // Update is called once per frame
    void Update()
    {
        if (stamina < 20f)
        {
            AddStamina(Time.deltaTime*1.5f);
            if (stamina > 20f) {stamina = 20;}
        }
        time -= Time.deltaTime;
        if (time < 0)
        {
            FindObjectOfType<PlayerMovement>().enabled = false;
            time = 0;
            inGame.SetActive(false);
            gameOver.SetActive(true);
            finalScore.SetText("Score: " + score.ToString());
        }
    }

    public void ReduceStamina(float value)
    {
        stamina -= value;
    }

    public void AddStamina(float value)
    {
        stamina += value;
    }

    public void SpawnTreant()
    {
        xPos = Random.Range(-7f, 7f);
        yPos = Random.Range(-3.5f, 3.5f);
        Instantiate(treantPrefab, new Vector3(xPos, yPos, 0), new Quaternion(0,0,0,0));
    }

    public void DeleteTreant(GameObject treant)
    {
        AddStamina(2);
        Destroy(treant);
        score += 1;
        SpawnTreant();
    }
}
