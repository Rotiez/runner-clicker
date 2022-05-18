using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Clicker : MonoBehaviour
{
    
    
    public int score;
    public Text clicktext;
    public Text clicktext1;
    public int click = 1;
    private int autoclick = 0;
        
    private int upgrade = 50;
    private int upgrade1 = 100;
    
    public Text upgradetext;
    public Text autoclicktext;
    
    private ClickObj[] clickTextPool = new ClickObj[15];
    
    void Start()
    {
        score = 0;
        score = PlayerPrefs.GetInt("Score+", score);
        autoclick = PlayerPrefs.GetInt("autoclick+",autoclick);
        click = PlayerPrefs.GetInt("Click+",click);

        for (int i = 0; i < clickTextPool.Length; i++)
        {
            clickTextPool[i] = Instantiate(FlyTextPrefab, ClickPoints.transform).GetComponent<ClickObj>();
        }
        
        StartCoroutine(IdleFarm());
    }

    
    void Update()
    {
        clicktext.text = score.ToString();
        clicktext1.text = score.ToString();
        if (upgrade <= 36450)
        {
            upgradetext.text = "Price: " + upgrade.ToString();
        }
        else
        {
            upgradetext.text = "Maximum";
        }
        
        if (upgrade1 <= 25600)
        {
            autoclicktext.text = "Price: " + upgrade1.ToString();
        }
        else
        {
            autoclicktext.text = "Maximum";
        }
    }

    public void UpgradeButton1()
    {
        if (score >= upgrade && upgrade <= 36450)
        {
            click *= 2;
            score -= upgrade;
            upgrade *= 3;
        }
        PlayerPrefs.SetInt("Click+",click);
    }
    
    public void AutoClickButton()
    {
        if (score >= upgrade1 && upgrade1 <= 25600)
        {
            autoclick += 1;
            score -= upgrade1;
            upgrade1 *= 4;
        }
    }
    

    public void ClickerScore()
    {
        score += click;
        PlayerPrefs.SetInt("Score+",score);
        clickTextPool[0].StartMotion(5);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene(1);
    }
    
    public void OnClickMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void OnClickShop()
    {
        SceneManager.LoadScene(2);
    }
    
    //Панель Upgrade
    
    public GameObject UpgradePan;

    public void OpenUpgradePan()
    {
        if (UpgradePan != null)
        {
            UpgradePan.SetActive(true);
        }
    }
    
    public void CloseUpgradePan()
    {
        if (UpgradePan != null)
        {
            UpgradePan.SetActive(false);
        }
    }
    
    //Вылетающие очки

    public GameObject ClickPoints, FlyTextPrefab;
    
    //Автоклики

    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(1);
        score += autoclick;
        PlayerPrefs.SetInt("Score+",score);
        StartCoroutine(IdleFarm());
        PlayerPrefs.SetInt("autoclick+",autoclick);
    }
    
}
