using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour {
    public long dbid = 0;
	// Use this for initialization
	void Start () {
        Tweener tw= transform.DOMove(new Vector3(UnityEngine.Random.Range(10,100), UnityEngine.Random.Range(10, 100), 200), 3f);
        tw.SetLoops(-1, LoopType.Yoyo);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
