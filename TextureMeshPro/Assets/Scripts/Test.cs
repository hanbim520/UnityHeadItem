using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Test : MonoBehaviour {

    public UIHeadBar uiHeadBar;
    public Sprite image;
    public List<Player> players = new List<Player>();
	// Use this for initialization
	void Start () {
        
        GameObject goPlayer = Resources.Load<GameObject>("Player");

        GameObject goHeadBar = Resources.Load<GameObject>("HeadBar");
        GameObject uiHeadBarGo = GameObject.Instantiate(goHeadBar);

        uiHeadBarGo.transform.localRotation = Quaternion.identity;
        uiHeadBarGo.transform.localPosition = Vector3.zero;
        uiHeadBarGo.transform.localScale = Vector3.one;

        uiHeadBar = uiHeadBarGo.GetComponent<UIHeadBar>();

        for (int i =0;i <1;++i)
        {
            GameObject pl = GameObject.Instantiate(goPlayer);
            pl.transform.localPosition = Vector3.zero;
            pl.transform.localRotation = Quaternion.identity;
            pl.transform.localScale = Vector3.one;
            Player player = pl.GetComponent<Player>();
            players.Add(player);
            player.dbid = i;
            uiHeadBar.CreateHeadBar((long)i, "张三对的的", "", "", null,UIHeadBar.ShowType.ePlayerNormal);
            uiHeadBar.SetChengHao(i,"[费大幅度]");
        }
        //[冒险家]
        //[工会名]
        //         GameObject pl = GameObject.Instantiate(goPlayer);
        //         pl.transform.localPosition = Vector3.zero;
        //         pl.transform.localRotation = Quaternion.identity;
        //         pl.transform.localScale = Vector3.one;
        //         Player player = pl.GetComponent<Player>();
        //         players.Add(player);
        //         player.dbid = 100;
        //         uiHeadBar.CreateHeadBar(100, "张三对的的", "[冒险家]", "[工会名]", image);
    }

    // Update is called once per frame
    void Update () {
		for(int i=0;i < players.Count;++i)
        {
            uiHeadBar.UpdateEntities(i, players[i].transform.position);
        }
	}
}
