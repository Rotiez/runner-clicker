using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Clicker : MonoBehaviour
{
    
    
    public static int score;
    public Text clicktext;
    public Text ScoreShop;
    public Text ScoreShopplanet;
    private int click = 1;
    private int autoclick = 0;
       
    private int upgrade = 50;
    private int upgrade1 = 50;
    
    public Text upgradetext;
    public Text autoclicktext;

    //Текст кнопок планет
    public Text TerrainText;
    public Text LavaText;
    public Text IceText;
    public Text BarenText;

    //Планеты
    private int Terrain = 1;
    private int Lava = 0;
    private int Ice = 0;
    private int Baren = 0;

    //Цены планет
    private int LavaPrice = 500;
    private int IcePrice = 2000;
    private int BarenPrice = 5000;

    //Выбор планеты
    public int ChoosePlanet = 1;

    //Sprite button change
    [SerializeField] private Sprite[] buttonSprites;
    [SerializeField] private Image TerrainButton;
    [SerializeField] private Image LavaButton;
    [SerializeField] private Image IceButton;
    [SerializeField] private Image BarenButton;
    
    private ClickObj[] clickTextPool = new ClickObj[15];
    
    void Start()
    {   
        Time.timeScale = 1;
        score = 0;
        score = PlayerPrefs.GetInt("Score+", score);
        autoclick = PlayerPrefs.GetInt("autoclick+",autoclick);
        click = PlayerPrefs.GetInt("Click+",click);
        upgrade = PlayerPrefs.GetInt("upgrade+",upgrade);
        upgrade1 = PlayerPrefs.GetInt("upgrade1+",upgrade1);
        Lava = PlayerPrefs.GetInt("Lava+",Lava);
        Ice = PlayerPrefs.GetInt("Ice+",Ice);
        Baren = PlayerPrefs.GetInt("Baren+",Baren);

        for (int i = 0; i < clickTextPool.Length; i++)
        {
            clickTextPool[i] = Instantiate(FlyTextPrefab, ClickPoints.transform).GetComponent<ClickObj>();
        }
        
        StartCoroutine(IdleFarm());
    }

    
    void Update()
    {
        clicktext.text = score.ToString();
        ScoreShop.text = score.ToString();
        ScoreShopplanet.text = score.ToString();
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

        //Земли

        if (Terrain == 1)
        {   
            if (ChoosePlanet == 1)
            {
                TerrainText.text = "Selected";
                TerrainButton.sprite = buttonSprites[1];
            }
            else
            {
                TerrainText.text = "Owned";
                TerrainButton.sprite = buttonSprites[0];
            }   
        }
        //////////////

        if (Lava == 1)
        {   
            if (ChoosePlanet == 2)
            {
                LavaText.text = "Selected";
                LavaButton.sprite = buttonSprites[1];
            }
            else
            {
                LavaText.text = "Owned";
                LavaButton.sprite = buttonSprites[0];
            }
            LavaLock.SetActive(false);
        }
    
        ///////////////
        if (Ice == 1)
        {
            if (ChoosePlanet == 3)
            {
                IceText.text = "Selected";
                IceButton.sprite = buttonSprites[1];
            }
            else
            {
                IceText.text = "Owned";
                IceButton.sprite = buttonSprites[0];
            }
            IceLock.SetActive(false);
        }
        ////////////////

        if (Baren == 1)
        {
            if (ChoosePlanet == 4)
            {
                BarenText.text = "Selected";
                BarenButton.sprite = buttonSprites[1];
            }
            else
            {
                BarenText.text = "Owned";
                BarenButton.sprite = buttonSprites[0];
            }
            BarenLock.SetActive(false);
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
        PlayerPrefs.SetInt("upgrade+",upgrade);
        PlayerPrefs.SetInt("Click+",click);
    }
    
    public void AutoClickButton()
    {
        if (score >= upgrade1 && upgrade1 <= 25600)
        {
            autoclick += 5;
            score -= upgrade1;
            upgrade1 *= 2;
        }
        PlayerPrefs.SetInt("upgrade1+",upgrade1);
        PlayerPrefs.SetInt("Click+",click);
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
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }


/////////////////////////////////////////////////////  
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

//////////////////////////////////////////////////////   
    //Панель Planets Shop
    
    public GameObject PlanetPan;

    public void OpenPlanetPan()
    {
        if (PlanetPan != null)
        {
            PlanetPan.SetActive(true);
        }
    }
    
    public void ClosePlanetPan()
    {
        if (PlanetPan != null)
        {
            PlanetPan.SetActive(false);
        }
    }

/////////////////////////////////////////////////////////
    //Выбор и покупка планет

    public GameObject LavaLock;
    public GameObject IceLock;
    public GameObject BarenLock;

    public GameObject TerrainPlanet;
    public GameObject LavaPlanet;
    public GameObject IcePlanet;
    public GameObject BarenPlanet;

    public void SelectTerrain()
    {   
        //Выбор планеты 1
        if (Terrain == 1 && ChoosePlanet != 1)
        {
            ChoosePlanet = 1;
            TerrainPlanet.SetActive(true);
            LavaPlanet.SetActive(false);
            IcePlanet.SetActive(false);
            BarenPlanet.SetActive(false);
        }
    }

    public void SelectLava()
    {   
        if (score >= LavaPrice && Lava != 1)
        {
            Lava = 1;
            score -= LavaPrice;
            LavaLock.SetActive(false);
        }
        PlayerPrefs.SetInt("Lava+",Lava);

        //Выбор планеты 2
        if (Lava == 1 && ChoosePlanet != 2)
        {
            ChoosePlanet = 2;
            TerrainPlanet.SetActive(false);
            LavaPlanet.SetActive(true);
            IcePlanet.SetActive(false);
            BarenPlanet.SetActive(false);
        }
    }

    public void SelectIce()
    {
        if (score >= IcePrice && Ice != 1)
        {
            Ice = 1;
            score -= IcePrice;
            IceLock.SetActive(false);
        }
        PlayerPrefs.SetInt("Ice+",Ice);

        //Выбор планеты 3
        if (Ice == 1 && ChoosePlanet != 3)
        {
            ChoosePlanet = 3;
            TerrainPlanet.SetActive(false);
            LavaPlanet.SetActive(false);
            IcePlanet.SetActive(true);
            BarenPlanet.SetActive(false);
        }
    }

    public void SelectBaren()
    {
        if (score >= BarenPrice && Baren != 1)
        {
            Baren = 1;
            score -= BarenPrice;
            BarenLock.SetActive(false);
        }
        PlayerPrefs.SetInt("Baren+",Baren);

        //Выбор планеты 4
        if (Baren == 1 && ChoosePlanet != 4)
        {
            ChoosePlanet = 4;
            TerrainPlanet.SetActive(false);
            LavaPlanet.SetActive(false);
            IcePlanet.SetActive(false);
            BarenPlanet.SetActive(true);
        }
    }

////////////////////////////////////////////////  
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
