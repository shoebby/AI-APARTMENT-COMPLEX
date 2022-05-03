using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverviewScript : MonoBehaviour
{
    [SerializeField] private GameObject overviewCam;
    [SerializeField] private GameObject overviewCanvas;

    public GameObject[] apartmentsGround;
    public GameObject[] apartmentsFirst;
    public GameObject[] apartmentsSecond;

    public GameObject floorGround;
    public GameObject floorFirst;
    public GameObject floorSecond;

    private int floorNum = 0;

    public enum State
    {
        Floor0,
        Floor1,
        Floor2,
    }

    public State state;

    IEnumerator Floor0()
    {
        Debug.Log("Floor 0: Entered");
        state = State.Floor0;
        floorGround.SetActive(true);
        floorFirst.SetActive(false);
        floorSecond.SetActive(false);

        for (int i = 0; i < apartmentsGround.Length; i++)
        {
            if (apartmentsGround[i].activeSelf == false)
                apartmentsGround[i].SetActive(true);
        }
        for (int i = 0; i < apartmentsFirst.Length; i++)
        {
            if (apartmentsFirst[i].activeSelf == true)
                apartmentsFirst[i].SetActive(false);
        }
        for (int i = 0; i < apartmentsSecond.Length; i++)
        {
            if (apartmentsSecond[i].activeSelf == true)
                apartmentsSecond[i].SetActive(false);
        }

        while (state == State.Floor0)
        {
            yield return 0;
        }
        Debug.Log("Floor 0: Exiting");
    }

    IEnumerator Floor1()
    {
        Debug.Log("Floor 1: Entered");
        state = State.Floor1;
        floorGround.SetActive(false);
        floorFirst.SetActive(true);
        floorSecond.SetActive(false);
        for (int i = 0; i < apartmentsGround.Length; i++)
        {
            if (apartmentsGround[i].activeSelf == true)
                apartmentsGround[i].SetActive(false);
        }
        for (int i = 0; i < apartmentsFirst.Length; i++)
        {
            if (apartmentsFirst[i].activeSelf == false)
                apartmentsFirst[i].SetActive(true);
        }
        for (int i = 0; i < apartmentsSecond.Length; i++)
        {
            if (apartmentsSecond[i].activeSelf == true)
                apartmentsSecond[i].SetActive(false);
        }
        while (state == State.Floor1)
        {
            yield return 0;
        }
        Debug.Log("Floor 1: Exiting");
    }

    IEnumerator Floor2()
    {
        Debug.Log("Floor 2: Entered");
        state = State.Floor2;
        floorGround.SetActive(false);
        floorFirst.SetActive(false);
        floorSecond.SetActive(true);
        for (int i = 0; i < apartmentsGround.Length; i++)
        {
            if (apartmentsGround[i].activeSelf == true)
                apartmentsGround[i].SetActive(false);
        }
        for (int i = 0; i < apartmentsFirst.Length; i++)
        {
            if (apartmentsFirst[i].activeSelf == true)
                apartmentsFirst[i].SetActive(false);
        }
        for (int i = 0; i < apartmentsSecond.Length; i++)
        {
            if (apartmentsSecond[i].activeSelf == false)
                apartmentsSecond[i].SetActive(true);
        }
        while (state == State.Floor2)
        {
            yield return 0;
        }
        Debug.Log("Floor 2: Exiting");
    }

    public void GoToApt(GameObject nextCam)
    {
        nextCam.SetActive(true);
        overviewCam.SetActive(false);
    }

    public void EnableConv(GameObject DialogueTrigger)
    {
        DialogueTrigger.SetActive(true);
        overviewCanvas.SetActive(false);
    }

    public void ChangeFloor(string methodName)
    {
        if (floorNum == 0 || floorNum == 1)
            floorNum += 1;
        else if (floorNum == 2)
            floorNum = 0;
        StartCoroutine("Floor" + floorNum);
    }
}
