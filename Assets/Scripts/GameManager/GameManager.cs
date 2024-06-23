using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public FarmScr farm;
    public BarnScr barn;

    public FieldScr Field1;
    public FieldScr Field2;
    public FieldScr Field3;

    public WorkshopScr WS;

    public bool GameIsStarted = true;

    public int tech;
    public int fame;
    public int money;

    public int techPlusAmount = 1;
    public int famePlusAmount = 1;

    [HideInInspector] public int haveMoney;
    [HideInInspector] public int haveTech;
    [HideInInspector] public int haveFame;

    [HideInInspector] public int haveWheet;
    [HideInInspector] public int haveVegetables;
    [HideInInspector] public int haveGrapes;

    [HideInInspector] public int haveEggs;
    [HideInInspector] public int haveWool;
    [HideInInspector] public int haveMilk;

    [HideInInspector] public int haveHens;
    [HideInInspector] public int haveSheeps;
    [HideInInspector] public int haveCows;

    [HideInInspector] public int haveField1Cap;
    [HideInInspector] public int haveField2Cap;
    [HideInInspector] public int haveField3Cap;

    public TextMeshProUGUI techText;
    public TextMeshProUGUI fameText;
    public TextMeshProUGUI moneyText;

    public TextMeshProUGUI techHouseShow;
    public TextMeshProUGUI fameHouseShow;

    public GameObject StartingScreen;

    public string path;

    public string dataDirPath;
    public string dataFileName;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

    }

    private void Update()
    {
        techText.text = CountText(tech);
        fameText.text = CountText(fame);
        moneyText.text = CountText(money);

        techHouseShow.text = CountText(tech);
        fameHouseShow.text = CountText(fame);

        CollectData();

        //StartCoroutine(BannerDisplayWithDelay());

        /*if(!GameIsStarted)
        {
            AdsManager.Instance.bannerAds.HideBannerAd();
        }*/
    }

    /*private IEnumerator BannerDisplayWithDelay()
    {
        yield return new WaitForSeconds(1f);
        AdsManager.Instance.bannerAds.ShowBannerAd();
    }*/

    #region StartNewGame

    public void StartNewGame()
    {
        StartingScreen.SetActive(false);
    }

    #endregion

    /*#region Save and Load

    private class SaveObject
    {
        public int saveMoney;
        public int saveFame;
        public int saveTech;

        public int saveWheet;
        public int saveVegetables;
        public int saveGrapes;

        public int saveEggs;
        public int saveWool;
        public int saveMilk;

        public int saveHens;
        public int saveSheeps;
        public int saveCows;

        #region WS Safe

        public int GMSI1;
        public int GMSI2;
        public int GMSI3;
        public int GMSI4;
        public int GMSI5;
        public int GMSI6;
        public int GMSI7;
        public int GMSI8;
        public int GMSI9;
        public int GMSI10;

        public int GMSI11;
        public int GMSI12;
        public int GMSI13;
        public int GMSI14;
        public int GMSI15;
        public int GMSI16;
        public int GMSI17;
        public int GMSI18;
        public int GMSI19;
        public int GMSI20;

        public int GMSI21;
        public int GMSI22;
        public int GMSI23;
        public int GMSI24;
        public int GMSI25;
        public int GMSI26;
        public int GMSI27;
        public int GMSI28;
        public int GMSI29;
        public int GMSI30;

        public int GMSI31;
        public int GMSI32;
        public int GMSI33;
        public int GMSI34;
        public int GMSI35;
        public int GMSI36;
        public int GMSI37;
        public int GMSI38;
        public int GMSI39;
        public int GMSI40;

        public int GMSI41;
        public int GMSI42;
        public int GMSI43;
        public int GMSI44;
        public int GMSI45;
        public int GMSI46;
        public int GMSI47;
        public int GMSI48;
        public int GMSI49;
        public int GMSI50;

        public int GMSI51;
        public int GMSI52;
        public int GMSI53;
        public int GMSI54;
        public int GMSI55;
        public int GMSI56;
        public int GMSI57;
        public int GMSI58;
        public int GMSI59;
        public int GMSI60;

        public int GMSI61;
        public int GMSI62;
        public int GMSI63;
        public int GMSI64;
        public int GMSI65;
        public int GMSI66;
        public int GMSI67;
        public int GMSI68;
        public int GMSI69;
        public int GMSI70;

        public int GMSI71;
        public int GMSI72;
        public int GMSI73;
        public int GMSI74;
        public int GMSI75;
        public int GMSI76;
        public int GMSI77;
        public int GMSI78;
        public int GMSI79;
        public int GMSI80;

        public int GMSI81;
        public int GMSI82;
        public int GMSI83;
        public int GMSI84;
        public int GMSI85;
        public int GMSI86;
        public int GMSI87;
        public int GMSI88;
        public int GMSI89;
        public int GMSI90;

        public int GMSI91;
        public int GMSI92;

        #endregion
    }

    public void SavePlayer()
    {
        EventsScr.Instance.EventPopText("Game Saved!");
        CollectData();
        WS.SaveWSInfo();

        SaveObject saveObject = new SaveObject
        {
            saveMoney = haveMoney,
            saveFame = haveFame,
            saveTech = haveTech,

            saveWheet = haveWheet,
            saveVegetables = haveVegetables,
            saveGrapes = haveGrapes,

            saveEggs = haveEggs,
            saveWool = haveWool,
            saveMilk = haveMilk,

            saveHens = haveHens,
            saveSheeps = haveSheeps,
            saveCows = haveCows,

            GMSI1 = WS.SI1,
            GMSI2 = WS.SI2,
            GMSI3 = WS.SI3,
            GMSI4 = WS.SI4,
            GMSI5 = WS.SI5,
            GMSI6 = WS.SI6,
            GMSI7 = WS.SI7,
            GMSI8 = WS.SI8,
            GMSI9 = WS.SI9,
            GMSI10 = WS.SI10,

            GMSI11 = WS.SI11,
            GMSI12 = WS.SI12,
            GMSI13 = WS.SI13,
            GMSI14 = WS.SI14,
            GMSI15 = WS.SI15,
            GMSI16 = WS.SI16,
            GMSI17 = WS.SI17,
            GMSI18 = WS.SI18,
            GMSI19 = WS.SI19,
            GMSI20 = WS.SI20,

            GMSI21 = WS.SI21,
            GMSI22 = WS.SI22,
            GMSI23 = WS.SI23,
            GMSI24 = WS.SI24,
            GMSI25 = WS.SI25,
            GMSI26 = WS.SI26,
            GMSI27 = WS.SI27,
            GMSI28 = WS.SI28,
            GMSI29 = WS.SI29,
            GMSI30 = WS.SI30,

            GMSI31 = WS.SI31,
            GMSI32 = WS.SI32,
            GMSI33 = WS.SI33,
            GMSI34 = WS.SI3,
            GMSI35 = WS.SI35,
            GMSI36 = WS.SI36,
            GMSI37 = WS.SI37,
            GMSI38 = WS.SI38,
            GMSI39 = WS.SI39,
            GMSI40 = WS.SI40,

            GMSI41 = WS.SI41,
            GMSI42 = WS.SI42,
            GMSI43 = WS.SI43,
            GMSI44 = WS.SI44,
            GMSI45 = WS.SI45,
            GMSI46 = WS.SI46,
            GMSI47 = WS.SI47,
            GMSI48 = WS.SI48,
            GMSI49 = WS.SI49,
            GMSI50 = WS.SI50,

            GMSI51 = WS.SI51,
            GMSI52 = WS.SI52,
            GMSI53 = WS.SI53,
            GMSI54 = WS.SI54,
            GMSI55 = WS.SI55,
            GMSI56 = WS.SI56,
            GMSI57 = WS.SI57,
            GMSI58 = WS.SI58,
            GMSI59 = WS.SI59,
            GMSI60 = WS.SI60,

            GMSI61 = WS.SI61,
            GMSI62 = WS.SI62,
            GMSI63 = WS.SI63,
            GMSI64 = WS.SI64,
            GMSI65 = WS.SI65,
            GMSI66 = WS.SI66,
            GMSI67 = WS.SI67,
            GMSI68 = WS.SI68,
            GMSI69 = WS.SI69,
            GMSI70 = WS.SI70,

            GMSI71 = WS.SI71,
            GMSI72 = WS.SI72,
            GMSI73 = WS.SI73,
            GMSI74 = WS.SI74,
            GMSI75 = WS.SI75,
            GMSI76 = WS.SI76,
            GMSI77 = WS.SI77,
            GMSI78 = WS.SI78,
            GMSI79 = WS.SI79,
            GMSI80 = WS.SI80,

            GMSI81 = WS.SI81,
            GMSI82 = WS.SI82,
            GMSI83 = WS.SI83,
            GMSI84 = WS.SI84,
            GMSI85 = WS.SI85,
            GMSI86 = WS.SI86,
            GMSI87 = WS.SI87,
            GMSI88 = WS.SI88,
            GMSI89 = WS.SI89,
            GMSI90 = WS.SI90,

            GMSI91 = WS.SI91,
            GMSI92 = WS.SI92

        };

        //FileStream filestream = new FileStrean();

        string json = JsonUtility.ToJson(saveObject);

        //File.Create()
        //path = Path.Combine();

        File.WriteAllText(Application.dataPath + "/save.txt", json);

        EventsScr.Instance.EventPopText("Game Save Complete!");
    }

    public void LoadPlayer()
    {
        if(File.Exists(Application.dataPath + "/save.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
            Debug.Log("Loaded: " + saveString);
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            haveMoney = saveObject.saveMoney;
            haveFame = saveObject.saveFame;
            haveTech = saveObject.saveTech;

            haveWheet = saveObject.saveWheet;
            haveVegetables = saveObject.saveVegetables;
            haveGrapes = saveObject.saveGrapes;

            haveEggs = saveObject.saveEggs;
            haveWool = saveObject.saveWool;
            haveMilk = saveObject.saveMilk;

            haveHens = saveObject.saveHens;
            haveSheeps = saveObject.saveSheeps;
            haveCows = saveObject.saveCows;

            WS.SI1 = saveObject.GMSI1;
            WS.SI2 = saveObject.GMSI2;
            WS.SI3 = saveObject.GMSI3;
            WS.SI4 = saveObject.GMSI4;
            WS.SI5 = saveObject.GMSI5;
            WS.SI6 = saveObject.GMSI6;
            WS.SI7 = saveObject.GMSI7;
            WS.SI8 = saveObject.GMSI8;
            WS.SI9 = saveObject.GMSI9;
            WS.SI10 = saveObject.GMSI10;

            WS.SI11 = saveObject.GMSI11;
            WS.SI12 = saveObject.GMSI12;
            WS.SI13 = saveObject.GMSI13;
            WS.SI14 = saveObject.GMSI14;
            WS.SI15 = saveObject.GMSI15;
            WS.SI16 = saveObject.GMSI16;
            WS.SI17 = saveObject.GMSI17;
            WS.SI18 = saveObject.GMSI18;
            WS.SI19 = saveObject.GMSI19;
            WS.SI20 = saveObject.GMSI20;

            WS.SI21 = saveObject.GMSI21;
            WS.SI22 = saveObject.GMSI22;
            WS.SI23 = saveObject.GMSI23;
            WS.SI24 = saveObject.GMSI24;
            WS.SI25 = saveObject.GMSI25;
            WS.SI26 = saveObject.GMSI26;
            WS.SI27 = saveObject.GMSI27;
            WS.SI28 = saveObject.GMSI28;
            WS.SI29 = saveObject.GMSI29;
            WS.SI30 = saveObject.GMSI30;

            WS.SI31 = saveObject.GMSI31;
            WS.SI32 = saveObject.GMSI32;
            WS.SI33 = saveObject.GMSI33;
            WS.SI34 = saveObject.GMSI34;
            WS.SI35 = saveObject.GMSI35;
            WS.SI36 = saveObject.GMSI36;
            WS.SI37 = saveObject.GMSI37;
            WS.SI38 = saveObject.GMSI38;
            WS.SI39 = saveObject.GMSI39;
            WS.SI40 = saveObject.GMSI40;

            WS.SI41 = saveObject.GMSI41;
            WS.SI42 = saveObject.GMSI42;
            WS.SI43 = saveObject.GMSI43;
            WS.SI44 = saveObject.GMSI44;
            WS.SI45 = saveObject.GMSI45;
            WS.SI46 = saveObject.GMSI46;
            WS.SI47 = saveObject.GMSI47;
            WS.SI48 = saveObject.GMSI48;
            WS.SI49 = saveObject.GMSI49;
            WS.SI50 = saveObject.GMSI50;

            WS.SI51 = saveObject.GMSI51;
            WS.SI52 = saveObject.GMSI52;
            WS.SI53 = saveObject.GMSI53;
            WS.SI54 = saveObject.GMSI54;
            WS.SI55 = saveObject.GMSI55;
            WS.SI56 = saveObject.GMSI56;
            WS.SI57 = saveObject.GMSI57;
            WS.SI58 = saveObject.GMSI58;
            WS.SI59 = saveObject.GMSI59;
            WS.SI60 = saveObject.GMSI60;

            WS.SI61 = saveObject.GMSI61;
            WS.SI62 = saveObject.GMSI62;
            WS.SI63 = saveObject.GMSI63;
            WS.SI64 = saveObject.GMSI64;
            WS.SI65 = saveObject.GMSI65;
            WS.SI66 = saveObject.GMSI66;
            WS.SI67 = saveObject.GMSI67;
            WS.SI68 = saveObject.GMSI68;
            WS.SI69 = saveObject.GMSI69;
            WS.SI70 = saveObject.GMSI70;

            WS.SI71 = saveObject.GMSI71;
            WS.SI72 = saveObject.GMSI72;
            WS.SI73 = saveObject.GMSI73;
            WS.SI74 = saveObject.GMSI74;
            WS.SI75 = saveObject.GMSI75;
            WS.SI76 = saveObject.GMSI76;
            WS.SI77 = saveObject.GMSI77;
            WS.SI78 = saveObject.GMSI78;
            WS.SI79 = saveObject.GMSI79;
            WS.SI80 = saveObject.GMSI80;

            WS.SI81 = saveObject.GMSI81;
            WS.SI82 = saveObject.GMSI82;
            WS.SI83 = saveObject.GMSI83;
            WS.SI84 = saveObject.GMSI84;
            WS.SI85 = saveObject.GMSI85;
            WS.SI86 = saveObject.GMSI86;
            WS.SI87 = saveObject.GMSI87;
            WS.SI88 = saveObject.GMSI88;
            WS.SI89 = saveObject.GMSI89;
            WS.SI90 = saveObject.GMSI90;

            WS.SI91 = saveObject.GMSI91;
            WS.SI92 = saveObject.GMSI92;

            SetDataFromSave();
            WS.LoadWSInfo();

            EventsScr.Instance.EventPopText("Game Loaded!");

            StartingScreen.SetActive(false);
        }
        else
        {
            EventsScr.Instance.EventPopText("No Saved File!");
        }
    }
    */

    private void CollectData()
    {
        haveMoney = money;
        haveFame = fame;
        haveTech = tech;

        haveWheet = farm.wheets;
        haveVegetables = farm.vegetables;
        haveGrapes = farm.grapes;

        haveEggs = barn.eggs;
        haveWool = barn.wool;
        haveMilk = barn.milk;

        haveHens = barn.hens;
        haveSheeps = barn.sheeps;
        haveCows = barn.cows;
    }

    public void SetDataFromSave()
    {
        money = haveMoney;
        fame = haveFame;
        tech = haveTech;

        farm.wheets = haveWheet;
        farm.vegetables = haveVegetables;
        farm.grapes = haveGrapes;

        barn.eggs = haveEggs;
        barn.wool = haveWool;
        barn.milk = haveMilk;

        barn.hens = haveHens;
        barn.sheeps = haveSheeps;
        barn.cows = haveCows;
    }

    //#endregion

    public void techByTurn()
    {
        tech += techPlusAmount;
    }

    public void fameByTurn()
    {
        fame += famePlusAmount;
    }

    public string CountText(int number)
    {
        if(number > 0)
        {
            if(number >= 1000000000)
            {
                float endNumber = number / 1000000000;
                string text = endNumber.ToString() + "B";
                return text;
            }
            else if(number >= 1000000)
            {
                float endNumber = number / 1000000;
                string text = endNumber.ToString() + "M";
                return text;
            }
            else if(number >= 10000)
            {
                float endNumber = number / 1000;
                string text = endNumber.ToString() + "K";
                return text;
            }
            else
            {
                string text = number.ToString();
                return text;
            }
        }
        else if(number < 0)
        {
           if(number <= -1000000000)
            {
                float endNumber = number / 1000000000;
                string text = endNumber.ToString() + "B";
                return text;
            }
            else if(number <= -1000000)
            {
                float endNumber = number / 1000000;
                string text = endNumber.ToString() + "M";
                return text;
            }
            else if(number <= -10000)
            {
                float endNumber = number / 1000;
                string text = endNumber.ToString() + "K";
                return text;
            }
            else
            {
                string text = number.ToString();
                return text;
            } 
        }
        else
        {
            string text = number.ToString();
            return text;   
        }
        
    }

    public void CapCheck(int number, int Cap, TextMeshProUGUI text, bool white)
    {
        if(number > Cap)
        {
            text.color = new Color(255, 0, 0, 255);
        }
        else
        {
            if(white)
                text.color = new Color(255,255,255,255);
            else
                text.color = new Color(0,0,0,255);
        }
    }

}
