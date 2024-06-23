using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    public GameManager GM;
    public WorkshopScr WS;
    public TurnScr TS;
    private const string saveKey = "mainSave";

    public void Save()
    {
        WS.SaveWSInfo();
        SaveManager.Save(saveKey, GetSaveSnapshot());
        EventsScr.Instance.EventPopText("Game Saved!");
    }

    private SaveData.PlayerInfo GetSaveSnapshot()
    {
        var data = new SaveData.PlayerInfo()
        {
            saveMoney = GM.haveMoney,
            saveFame = GM.haveFame,
            saveTech = GM.haveTech,

            saveWheet = GM.haveWheet,
            saveVegetables = GM.haveVegetables,
            saveGrapes = GM.haveGrapes,

            saveEggs = GM.haveEggs,
            saveWool = GM.haveWool,
            saveMilk = GM.haveMilk,

            saveHens = GM.haveHens,
            saveSheeps = GM.haveSheeps,
            saveCows = GM.haveCows,

            Turns = TS.turnCount,
            AdTurns = TS.AdTurns,

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

        return data;
    }

    public void Load()
    {
        var saveObject = SaveManager.Load<SaveData.PlayerInfo>(saveKey);

        GM.haveMoney = saveObject.saveMoney;
        GM.haveFame = saveObject.saveFame;
        GM.haveTech = saveObject.saveTech;

        GM.haveWheet = saveObject.saveWheet;
        GM.haveVegetables = saveObject.saveVegetables;
        GM.haveGrapes = saveObject.saveGrapes;

        GM.haveEggs = saveObject.saveEggs;
        GM.haveWool = saveObject.saveWool;
        GM.haveMilk = saveObject.saveMilk;

        GM.haveHens = saveObject.saveHens;
        GM.haveSheeps = saveObject.saveSheeps;
        GM.haveCows = saveObject.saveCows;

        TS.turnCount = saveObject.Turns;
        TS.AdTurns = saveObject.AdTurns;

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

        WS.LoadWSInfo();

        GM.SetDataFromSave();
        GM.StartingScreen.SetActive(false);
        EventsScr.Instance.EventPopText("Game Loaded!");

    }
}
