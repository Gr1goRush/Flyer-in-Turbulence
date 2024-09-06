using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Shop : MonoBehaviour
    
{
    [SerializeField] Text moneyText;
    [SerializeField] GameObject PlaneShop, FonShop;
    [SerializeField] GameObject Panel1, Panel2, Panel3, Panel4, Panel5, Panel6, Panel7;
    [SerializeField] GameObject price2,price3,price5,price6,price7;
    int activateFon, activatePlane;
    bool buy1, buy2, buy3, buy4, buy5, buy6,buy7= false;
    [SerializeField]GameObject fon,player;
    [SerializeField]Sprite[] Fons,Skins;
    // Start is called before the first frame update
    void Start()
    {
        StartUpdate();
        PlaneUpadate();
        Ochist();
        OchistPlane();
        activateFon = PlayerPrefs.GetInt("fon");
        activatePlane = PlayerPrefs.GetInt("skin");
        buy1 = true;
        buy2 = PlayerPrefs.GetInt("buy2") == 1 ? true : false;
        buy3 = PlayerPrefs.GetInt("buy3") == 1 ? true : false;
        buy4 = true;
        buy5 = PlayerPrefs.GetInt("buy5") == 1 ? true : false;
        buy6 = PlayerPrefs.GetInt("buy6") == 1 ? true : false;
        buy7 = PlayerPrefs.GetInt("buy7") == 1 ? true : false;
        Chek();
    }

    // Update is called once per frame
    void Update()
    {
        PlaneUpadate();
        moneyText.text = PlayerPrefs.GetInt("money").ToString();
        FonUpadate();
        Chek();
    }
    public void SwitchShop()
    {
        PlaneShop.SetActive(!PlaneShop.active);
        FonShop.SetActive(!FonShop.active);
    }
    public void ChoseSkinFon1()
    {

        activateFon = 1;
        Ochist();
       

    }
    public void ChoseSkinFon2()
    {
        if (buy2 == true)
        {
            activateFon = 2;
            Ochist();
            
        }
        else
        {
            if (PlayerPrefs.GetInt("money")>=5)
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 5);
                buy2 = true;
                PlayerPrefs.SetInt("buy2",true?1:0);
            }
        }
    }
    public void ChoseSkinFon3()
    {
        if (buy3 == true)
        {
            activateFon = 3;
            Ochist();
            
        }
        else
        {
            if (PlayerPrefs.GetInt("money") >= 25)
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 25);
                buy3 = true;
                PlayerPrefs.SetInt("buy3", true ? 1 : 0);
            }
        }
    }
    public void ChoseSkinPlane1()
    {

        activatePlane = 1;
        OchistPlane();


    }
    public void ChoseSkinPlane2()
    {

        if (buy5 == true)
        {
            activatePlane = 2;
            OchistPlane();

        }
        else
        {
            if (PlayerPrefs.GetInt("money") >= 5)
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 5);
                buy5 = true;
                PlayerPrefs.SetInt("buy5", true ? 1 : 0);
            }
        }
    }
    public void ChoseSkinPlane3()
    {

        if (buy6 == true)
        {
            activatePlane = 3;
            OchistPlane();

        }
        else
        {
            if (PlayerPrefs.GetInt("money") >= 25)
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 25);
                buy6 = true;
                PlayerPrefs.SetInt("buy6", true ? 1 : 0);
            }
        }
    }
    public void ChoseSkinPlane4()
    {

        if (buy7 == true)
        {
            activatePlane = 4;
            OchistPlane();

        }
        else
        {
            if (PlayerPrefs.GetInt("money") >= 100)
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 100);
                buy7 = true;
                PlayerPrefs.SetInt("buy7", true ? 1 : 0);
            }
        }
    }
    public void Ochist()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
    }
    public void OchistPlane()
    {
       
         Panel4.SetActive(false);
         Panel5.SetActive(false);
          Panel6.SetActive(false);
         Panel7.SetActive(false);
    }
    public void Chek()
    {
        if (buy2==true)
        {
            price2.SetActive(false);
        }
        if(buy3 == true)
        {
            price3.SetActive(false);
        }
        if (buy5 == true)
        {
            price5.SetActive(false);
        }
        if (buy6 == true)
        {
            price6.SetActive(false);
        }
        if (buy7 == true)
        {
            price7.SetActive(false);
        }
    }
    public void FonUpadate()
    {
        PlayerPrefs.SetInt("fon", activateFon);
        if (activateFon == 1)
        {
            Panel1.SetActive(true);
            fon.GetComponent<SpriteRenderer>().sprite = Fons[0];
        }
        if (activateFon == 2)
        {
            Panel2.SetActive(true);
            fon.GetComponent<SpriteRenderer>().sprite = Fons[1];
        }
        if (activateFon == 3)
        {
            Panel3.SetActive(true);
            fon.GetComponent<SpriteRenderer>().sprite = Fons[2];
        }
    }
    public void PlaneUpadate()
    {
        PlayerPrefs.SetInt("skin", activatePlane);
        if (activatePlane == 1)
        {
            Panel4.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[0];
        }
        if (activatePlane == 2)
        {
            Panel5.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[1];
        }
        if (activatePlane == 3)
        {
            Panel6.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[2];
        }
        if (activatePlane == 4)
        {
            Panel7.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[3];
        }
    }
    public void StartUpdate()
    {
        if (activatePlane == 1)
        {
            Panel4.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[0];
        }
        if (activatePlane == 2)
        {
            Panel5.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[1];
        }
        if (activatePlane == 3)
        {
            Panel6.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[2];
        }
        if (activatePlane == 4)
        {
            Panel7.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[3];
        }
        PlayerPrefs.SetInt("fon", activateFon);
        if (activateFon == 1)
        {
            Panel1.SetActive(true);
            fon.GetComponent<SpriteRenderer>().sprite = Fons[0];
        }
        if (activateFon == 2)
        {
            Panel2.SetActive(true);
            fon.GetComponent<SpriteRenderer>().sprite = Fons[1];
        }
        if (activateFon == 3)
        {
            Panel3.SetActive(true);
            fon.GetComponent<SpriteRenderer>().sprite = Fons[2];
        }
    }

}
