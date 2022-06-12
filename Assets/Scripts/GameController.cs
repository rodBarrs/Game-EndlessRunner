 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameOver;
    public float score;
    public Text scoreText;
    public Text scoreCoinText;
    private Player player;
    public int scoreCoin = 0;
    private bool podePegarMoeda = false;


    // Start is called before the first frame update
    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isDead)
        {
            score += Time.deltaTime * 6f;
            scoreText.text = Mathf.Round(score).ToString() + "m";
            podePegarMoeda = true;
        }
       

    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void AddCoin()
    {
        if (podePegarMoeda)
        {


            scoreCoin = scoreCoin + 1;

            scoreCoinText.text = scoreCoin.ToString();
            podePegarMoeda = false;

        }
    }
}
