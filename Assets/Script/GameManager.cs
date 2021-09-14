using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI GameTitileText;
    public Button reStart;
    public Button easyM;
    public Button mediumM;
    public Button hardM;
    public bool isGameActive;
    private int score;
    [SerializeField] private float spawnRate = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawmTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        reStart.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void startGame(int diffculty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= diffculty;
        StartCoroutine(SpawmTarget());
        UpdateScore(0);
        easyM.gameObject.SetActive(false);
        mediumM.gameObject.SetActive(false);
        hardM.gameObject.SetActive(false);
        GameTitileText.gameObject.SetActive(false);
    }
}
