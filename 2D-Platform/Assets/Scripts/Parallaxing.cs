﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    [SerializeField]
    private  Vector2 parralaxMulitplier;
    private float textureUnitSizeX;
    // private float textureUnitSizeY; Only needed for vertical parralaxing


    private void Start() {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
       Sprite sprite = GetComponent<SpriteRenderer>().sprite;
       Texture2D texture = sprite.texture;
       textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    //    textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }

    private void LateUpdate() {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position+=new Vector3(deltaMovement.x*parralaxMulitplier.x,deltaMovement.y*parralaxMulitplier.y);
        lastCameraPosition = cameraTransform.position;

        if(Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {   float offsetPositionX = (cameraTransform.position.x - transform.position.x)%textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
        }
        // if(Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY)
        // {   float offsetPositionY = (cameraTransform.position.y - transform.position.y)%textureUnitSizeY;
        //     transform.position = new Vector3(transform.position.x,cameraTransform.position.y + offsetPositionY);
        // }
    }
}
