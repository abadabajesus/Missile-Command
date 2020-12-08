using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    EnemyMissileSpawner myEnemyMissileSpawner;
    [SerializeField] private GameObject endOfRoundPanel;
    public int score = 0;
    public int level = 1;
    public int playerMissilesLeft = 30;
    private int enemyMissilesThisRound = 20;
    private int enemyMissilesLeftInThisRound = 0;

    //score
    private int missileDestroyedPoints = 25;



    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI missilesLeftText;
    [SerializeField] private int missileEndOfRoundPoints = 5;
    [SerializeField] private int CityEndOfRoundPoints = 100;

    //[SerializeField] private TextMeshProUGUI leftOverMissileBonusText;
    //[SerializeField] private TextMeshProUGUI leftOverCityBonusText;
    //[SerializeField] private TextMeshProUGUI totalBonusText;

    // Start is called before the first frame update
    void Start()
    {
        myEnemyMissileSpawner = GameObject.FindObjectOfType<EnemyMissileSpawner>();
        UpdateScoreText();
        UpdateLevelText();
        UpdateMissilesLeft();

        StartRound();

    }

    // Update is called once per frame
    void Update()
    {
        //if (enemyMissilesLeftInThisRound <= 0)
        //{
        //    Debug.Log("Round us iver");

        //}
    }


    public void UpdateMissilesLeft()
    {
        missilesLeftText.text = "Missiles Left: " +
            "" + playerMissilesLeft;
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateLevelText()
    {
        levelText.text = "level: " + level;
    }

    public void AddMissileDetroyedScore()
    {
        score += missileDestroyedPoints;
        UpdateScoreText();
    }



    private void StartRound()
    {
        //myEnemyMissileSpawner.missilesToSpawn = enemyMissilesThisRound;
        myEnemyMissileSpawner.StartRound();
    }

    public IEnumerator EndOfRound()
    {
        yield return new WaitForSeconds(.5f);
        endOfRoundPanel.SetActive(true);
        int leftOverMissileBonus = playerMissilesLeft * missileEndOfRoundPoints;
        //GameObject[] cities = GameObject.FindObjectsOfType<City>();
        //int leftOverCityBonus = cities * CityEndOfRoundPoints;

        //int totalBonus = leftOverCityBonus + leftOverMissileBonus;
    }

}
