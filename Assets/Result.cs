using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;

public class Result : MonoBehaviour
{
    [SerializeField] Button retryButton;

    void Start()
    {
        retryButton.onClick.AddListener(() =>
        {
            Application.LoadLevel("Puzzle");
        });
    }
}
