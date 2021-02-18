using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public int treeCount = 5;
    public int cut1Count = 5;
    public int cut2Count = 5;
    public int maxTrees = 12, maxCut1 = 20, maxCut2 = 20;

    public Button treeCountBtn;
    public Button cut1CountBtn;
    public Button cut2CountBtn;

    private string treeCountTxt;
    private string cut1CountTxt;
    private string cut2CountTxt;
    public int cuttedTrees = 0;
    public GameObject pointer;
    public Text winTxt;
    public GameObject winCanvas;

    public DateTime startTime;
    private bool notYetWin = true;
    public GameObject PlayerHead;
    public bool updated = false;
    public Button zapiszBtn;

    // Start is called before the first frame update
    void Start()
    {
        treeCountTxt = treeCountBtn.GetComponentInChildren<Text>().text;
        cut1CountTxt = cut1CountBtn.GetComponentInChildren<Text>().text;
        cut2CountTxt = cut2CountBtn.GetComponentInChildren<Text>().text;

        treeCountBtn.GetComponentInChildren<Text>().text = treeCountTxt + treeCount;
        cut1CountBtn.GetComponentInChildren<Text>().text = cut1CountTxt + cut1Count;
        cut2CountBtn.GetComponentInChildren<Text>().text = cut2CountTxt + cut2Count;
        winCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(cuttedTrees>=treeCount && notYetWin && updated)
        {
            notYetWin = false;
            DateTime endTime = DateTime.Now;
            endTime.Subtract(startTime);
            
            pointer.SetActive(true);
            winCanvas.SetActive(true);

            winTxt.text = "Gratulacje! Wycięto " + cuttedTrees + " drzew!";
        }
    }

    public void TreeCountAdd()
    {
        if (treeCount < maxTrees)
        {
            treeCount++;
            treeCountBtn.GetComponentInChildren<Text>().text = treeCountTxt + treeCount;
        }
    }

    public void TreeCountSubtract()
    {
        if (treeCount > 1)
        {
            treeCount--;
            treeCountBtn.GetComponentInChildren<Text>().text = treeCountTxt + treeCount;
        }
    }

    public void Cut1Add()
    {
        if (cut1Count < maxCut1)
        {
            cut1Count++;
            cut1CountBtn.GetComponentInChildren<Text>().text = cut1CountTxt + cut1Count;
        }
    }           
                
    public void Cut1Subtract()
    {
        if (cut1Count > 1)
        {
            cut1Count--;
            cut1CountBtn.GetComponentInChildren<Text>().text = cut1CountTxt + cut1Count;
        }
    }

    public void Cut2Add()
    {
        if (cut2Count < maxCut2)
        {
            cut2Count++;
            cut2CountBtn.GetComponentInChildren<Text>().text = cut2CountTxt + cut2Count;
        }
    }

    public void Cut2Subtract()
    {
        if (cut2Count > 1)
        {
            cut2Count--;
            cut2CountBtn.GetComponentInChildren<Text>().text = cut2CountTxt + cut2Count;
        }
    }

    public void ZapiszPressed()
    {
        pointer.SetActive(false);
        startTime = DateTime.Now;
        updated = true;
        zapiszBtn.GetComponentInChildren<Text>().text = "Zapisano!";
    }

    public void ZakonczPressed()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

}
