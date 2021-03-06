﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kessan : MonoBehaviour {
    // 計算の際の会社カードに対応した色の環境パラメータ
    int income = 0;
    int env_para = 0;

    // 会社の収入を配列で保存[未上場/上場Flg, env_para-1 or 3]
    //Red
    int[, ] constructor = { { 1000, 4600 }, { 1300, 5600 }, { 1600, 6600 }, { 2000, 7600 }, { 2400, 8600 } }; //0
    int[, ] guest_house = { { 1100, 4800 }, { 1500, 5800 }, { 1800, 6800 }, { 2200, 7800 }, { 2700, 8800 } }; //1
    int[, ] convenient_store = { { 600, 4000 }, { 800, 5000 }, { 1000, 6000 }, { 1200, 7000 }, { 1500, 8000 } }; //2
    int[, ] family_restaurant = { { 800, 4200 }, { 1000, 5200 }, { 1200, 6200 }, { 1500, 7200 }, { 1800, 8200 } }; //3
    int[, ] caffe = { { 900, 4500 }, { 1200, 5500 }, { 1500, 6500 }, { 1800, 7500 }, { 2300, 8500 } }; //4
    int[, ] apparel = { { 1500, 5500 }, { 2000, 6500 }, { 2500, 7500 }, { 3000, 8500 }, { 3800, 9500 } }; //5
    int[, ] influencer = { { 1400, 5200 }, { 1800, 6200 }, { 2200, 7200 }, { 2700, 8200 }, { 3300, 9200 } }; //6
    //Green
    int[, ] agriculture = { { 1000, 4600 }, { 1300, 5600 }, { 1600, 6600 }, { 2000, 7600 }, { 2400, 8600 } }; //7
    int[, ] insurance_agency = { { 800, 4200 }, { 1000, 5200 }, { 1200, 6200 }, { 1500, 7200 }, { 1800, 8200 } }; //8
    int[, ] pharmacy = { { 900, 4500 }, { 1200, 5500 }, { 1500, 6500 }, { 1800, 7500 }, { 2300, 8500 } }; //9
    int[, ] power_company = { { 1400, 5200 }, { 1800, 6200 }, { 2200, 7200 }, { 2700, 8200 }, { 3300, 9200 } }; //10
    int[, ] pharmaceutical_company = { { 1500, 5500 }, { 2000, 6500 }, { 2500, 7500 }, { 3000, 8500 }, { 2800, 9500 } }; //11
    int[, ] real_estate = { { 600, 4000 }, { 800, 5000 }, { 1000, 6000 }, { 1200, 7000 }, { 1500, 8000 } }; //12
    int[, ] biomass = { { 1100, 4800 }, { 1500, 5800 }, { 1800, 6800 }, { 2200, 7800 }, { 2700, 8800 } }; //13
    //Blue
    int[, ] tv_station = { { 1000, 4600 }, { 1300, 5600 }, { 1600, 6600 }, { 2000, 7600 }, { 2400, 8600 } }; //14
    int[, ] web_production = { { 900, 4500 }, { 1200, 5500 }, { 1500, 6500 }, { 1800, 7500 }, { 2300, 8500 } }; //15
    int[, ] robotics = { { 1500, 5500 }, { 2000, 6500 }, { 2500, 7500 }, { 3000, 8500 }, { 3800, 9500 } }; //16
    int[, ] pg_school = { { 700, 4100 }, { 900, 5100 }, { 1100, 6100 }, { 1400, 7100 }, { 1700, 8100 } }; //17
    int[, ] ad_agency = { { 1400, 5200 }, { 1800, 6200 }, { 2200, 7200 }, { 2700, 8200 }, { 3300, 9200 } }; //18
    int[, ] video_production = { { 1100, 4800 }, { 1500, 5800 }, { 1800, 6800 }, { 2200, 7800 }, { 2700, 8800 } }; //19
    int[, ] it_company = { { 800, 4200 }, { 1000, 5200 }, { 1200, 6200 }, { 1500, 7200 }, { 1800, 8200 } };

    // 収入計算
    public void kessanIvent () {
        //Debug.Log (PlusMinusButton.techText_g.text);
        //Debug.Log (PlusMinusButton2.keikiText_g.text);
        //Debug.Log (PlusMinusButton3.kankyoText_g.text);
        //Debug.Log (CorpCreate.Listed_flg[0]);

        List<string> corp_list = new List<string> ();
        // corp_name_listから_Xを削除
        corp_list.Clear ();
        for (int i = 0; i < CorpCreate.corp_name_list.Count; i++) {
            string[] arr = CorpCreate.corp_name_list[i].Split ('_');
            corp_list.Add (arr[0]);
        }

        // 決算
        int total_income = 0;
        for (int i = 0; i < corp_list.Count; i++) {
            referenceFunc (CorpCreate.Listed_flg[i], corp_list[i]);
            total_income = total_income + income;

            Debug.Log ("income:" + income);
            Debug.Log ("Flg:" + CorpCreate.Listed_flg[i]);
            Debug.Log (total_income);
        }
    }
    // 会社名に対応した金額と環境パラメータをincomとenv_paraに格納
    void referenceFunc (int Flg, string corp) {
        // 環境パラメータを要素番号に変更
        /*if (Flg == 0) { //未上場
            switch (corp) {
                case "0":
                    env_para = int.Parse (PlusMinusButton2.keikiText_g.text) - 1;
                    income = constructor[env_para, Flg];
                    break;
                case "1":
                    env_para = int.Parse (PlusMinusButton2.keikiText_g.text) - 1;
                    income = guest_house[env_para, Flg];
                    break;
                case "2":
                    env_para = int.Parse (PlusMinusButton2.keikiText_g.text) - 1;
                    income = convenient_store[env_para, Flg];
                    break;
                case "3":
                    env_para = int.Parse (PlusMinusButton2.keikiText_g.text) - 1;
                    income = family_restaurant[env_para, Flg];
                    break;
                case "4":
                    env_para = int.Parse (PlusMinusButton2.keikiText_g.text) - 1;
                    income = caffe[env_para, Flg];
                    break;
                case "5":
                    env_para = int.Parse (PlusMinusButton2.keikiText_g.text) - 1;
                    income = apparel[env_para, Flg];
                    break;
                case "6":
                    env_para = int.Parse (PlusMinusButton2.keikiText_g.text) - 1;
                    income = influencer[env_para, Flg];
                    break;

                case "7":
                    env_para = int.Parse (PlusMinusButton3.keikiText_g.text) - 1;
                    income = influencer[env_para, Flg];
                    break;
                case "8":
                    break;

                case "9":
                    break;

                case "10":
                    break;

                case "11":
                    break;

                case "12":
                    break;

                case "13":
                    break;

                case "14":
                    break;

                case "15":
                    break;

                case "16":
                    break;

                case "17":
                    env_para = int.Parse (PlusMinusButton.techText_g.text) - 1;
                    income = PG_school[env_para, Flg];
                    break;

                case "18":
                    break;

                case "19":
                    break;

                case "20":
                    env_para = int.Parse (PlusMinusButton.techText_g.text) - 1;
                    income = IT_company[env_para, Flg];
                    break;
            }
        } else if (Flg == 1) { //上場
            switch (corp) {
                case "0":
                    break;

                case "1":
                    break;

                case "2":
                    break;

                case "3":
                    break;

                case "4":
                    break;

                case "5":
                    break;

                case "6":
                    break;

                case "7":
                    break;

                case "8":
                    break;

                case "9":
                    break;

                case "10":
                    break;

                case "11":
                    break;

                case "12":
                    break;

                case "13":
                    break;

                case "14":
                    break;

                case "15":
                    break;

                case "16":
                    break;

                case "17":
                    env_para = int.Parse (PlusMinusButton.techText_g.text) - 3;
                    income = PG_school[env_para, Flg];
                    break;

                case "18":
                    break;

                case "19":
                    break;

                case "20":
                    env_para = int.Parse (PlusMinusButton.techText_g.text) - 3;
                    income = IT_company[env_para, Flg];
                    break;
            }
        }
        */
    }

    // Start is called before the first frame update
    void Start () {

    }
    // Update is called once per frame
    void Update () {

    }
}