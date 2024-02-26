using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor;

public class SpriteControllerDecorator : SpriteController
{
    private int totalClicks = 0;

    public override void OnMouseDown()
    {
        base.OnMouseDown();

        totalClicks++;

        if (totalClicks % 20 == 0) {
            clicks += 3;
        }
    }

}