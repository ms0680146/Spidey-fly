using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class MotionSickness : MonoBehaviour {

    public Rigidbody Player;
    public VignetteAndChromaticAberration v;

    public const float MaxSpeed = 10f;
    public const float MaxLimit = 0.6f;

	// Update is called once per frame
	void Update () {
        float scale = Player.velocity.magnitude / MaxSpeed * MaxLimit;
        Debug.Log(scale);

        //若體驗者速度高於最高速度時，Vigette直接給MaxLimit的值
        if (Player.velocity.magnitude > MaxSpeed)
            scale = MaxLimit;
        //其餘的給計算出來scale的值
        v.intensity = scale;	
	}
}
