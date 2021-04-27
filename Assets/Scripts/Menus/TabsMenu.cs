using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabsMenu : MonoBehaviour
{

    [SerializeField] private GameObject[] gameObjects;
    private int activeMenu;
    void Start()
    {
        DisableAll();
        gameObjects[0].SetActive(true);
        activeMenu = 0;
    }

    public void ChangeActiveMenu(int value)
    {
        gameObjects[activeMenu].SetActive(false);
        gameObjects[value].SetActive(true);
        activeMenu = value;
    }

    public void DisableAll()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }
    }

}
