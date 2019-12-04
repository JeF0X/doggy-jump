﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class ButtonAnimation : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;

    Button button;
    Vector3 startingPos;
    bool mouseOver = false;

    void Start()
    {
        button = GetComponent<Button>();
        startingPos = transform.position;
    }

    private void Update()
    {
        if (mouseOver)
        {
            if (period <= Mathf.Epsilon) { return; }
            float cycles = Time.time / period; // grows constintaly from 0

            const float tau = Mathf.PI * 2f;
            float rawSineWave = Mathf.Sin(cycles * tau); // goers from -1 to +1

            float movementFactor = rawSineWave / 2f + 0.5f;
            Vector3 offset = movementVector * movementFactor;
            transform.position = startingPos + offset;
        }       
    }

    public void OnPointerEnter()
    {
        mouseOver = true;
    }

    public void OnPointerExit()
    {
        mouseOver = false;
    }

}
