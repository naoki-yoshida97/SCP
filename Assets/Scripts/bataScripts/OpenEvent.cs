﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenEvent : MonoBehaviour{
    int num = 0;
    string var = "EventView";
    //private List<int> list = new List<int>();
    List<int> list = EventOpen.list;
    // ダイアログを追加する親のCanvas
    [SerializeField] private Canvas parent = default;
    // 表示するダイアログ
    [SerializeField] private ClickEvent dialog = default;

    public void ShowEventOnClick(){
        // 生成してCanvasの子要素に設定
        var _dialog = Instantiate(dialog);
        _dialog.transform.SetParent(parent.transform, false);
        // ボタンが押されたときのイベント処理
        _dialog.FixDialog = result => Debug.Log(result);


        Debug.Log("押された!");  // ログを出力

        int v = -400;
        if(list!=null){
            for(int i=0; i<list.Count; i++){
            
                GameObject corp = new GameObject(var+i.ToString());
                corp.transform.parent = GameObject.Find ("Pane-ra").transform;

                // 画像のアンカーポジションを追加
                corp.AddComponent<RectTransform> ().anchoredPosition = new Vector3 (v, 50, 0);

                // 縮尺を変更
                corp.GetComponent<RectTransform> ().localScale = new Vector3 (2, 2, 0);

                // スプライト画像追加
                corp.AddComponent<Image> ().sprite = Resources.Load<Sprite>(list[i].ToString());

                // アスペクト比を元画像と同じサイズにする
                corp.GetComponent<Image> ().preserveAspect = true;
                v += 250;
                Debug.Log(list[i]);
                Debug.Log("表示するしゅば!(>_<)#"+i);
                Debug.Log(v+" "+i);
            }
        }
        
        Debug.Log("表示された");
    }
}