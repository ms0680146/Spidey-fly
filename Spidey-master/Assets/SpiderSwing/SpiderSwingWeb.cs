using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSwingWeb : MonoBehaviour {

    public GameObject controller;
    public LineRenderer line;

    public Rigidbody player;
    private Vector3 target;

    private AudioSource src;


    void Start()
    {
        src = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
        //Press One touch!
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)||Input.GetButtonDown("Fire1"))
        {
            //The Position what we detect!
            RaycastHit hit;
            if(Physics.Raycast(controller.transform.position,controller.transform.forward, out hit))
            {
                src.Play();
                line.enabled = true;
                //Start Line Position!
                line.SetPosition(0, controller.transform.position);
                //End Line Position!
                target = hit.point;
                line.SetPosition(1, target);
                //Addforce to let player move
                player.AddForce((target- controller.transform.position).normalized*20f);

                //Texture offset效果初始化
                line.material.mainTextureOffset = Vector2.zero;
            }
        //Keep Press!
        }else if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || Input.GetButton("Fire1") && line.enabled)
        {
            //src.Play();
            line.SetPosition(0, controller.transform.position);
            line.material.mainTextureOffset = new Vector2(line.material.mainTextureOffset.x + Random.Range(-.01f,0.05f), 0f);  //Texture Offset 效果

            player.AddForce((target- controller.transform.position).normalized * 20f);
            //Release!
        } else
        {
            line.enabled = false;
        }
	}
}
