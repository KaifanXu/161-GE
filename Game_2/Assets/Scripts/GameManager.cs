using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public controller controller;
    public Texture playerHealthTexture;

    public float screenPositionX;
    public float screenPositionY;

    public int iconSizeX = 25;
    public int iconSizeY = 25;

    public int playerHealth = 3;


    public string Level;
    //public string start;

    GameObject player;

    public int curEXP = 0;
    int maxEXP = 50;
    int level = 1;

    bool playerStats;

    public GUIText statsDisplay;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	void Update(){
       

        if (curEXP >= maxEXP)
        {
            LevelUp();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerStats = !playerStats;
        }
        if (playerStats)
        {
            statsDisplay.text = "Level: " + level + "\nExp: " + curEXP + "/" + maxEXP;
        }
        else
        {
            statsDisplay.text = "";
        }
    }

    void LevelUp()
    {
        curEXP = 0;
        maxEXP = maxEXP + 50;
        level++;
        playerHealth++;
        if(playerHealth >= 5)
        {
            winState(); 
        }
    }
    void OnGUI(){

        //控制角色生命值的心的显示  
        for (int h = 0; h < playerHealth; h++){
            GUI.DrawTexture(new Rect(screenPositionX + (h * iconSizeX), screenPositionY, iconSizeX, iconSizeY), playerHealthTexture, ScaleMode.ScaleToFit, true, 0);
        }
    }
    
    void PlayerDamaged(int damage){
        if (GetComponent<Renderer>().enabled)
        {

            if (playerHealth > 0)
            {
                playerHealth -= damage;
            }

            if (playerHealth <= 0)
            {
                RestartScene();
            }
        }
    }
    void winState()
    {
        Application.LoadLevel(Level);
    }
    void RestartScene(){
        Application.LoadLevel(Application.loadedLevel);
    }
}
