using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsMenu : MonoBehaviour
{


    [SerializeField] private GameObject trophiesMenu;
    [SerializeField] private GameObject statsMenu;


    void Start()
    {
        trophiesMenu.SetActive(false);
        statsMenu.SetActive(true);
    }

    public void ActivateTrophiesMenu()
    {
        trophiesMenu.SetActive(true);
        statsMenu.SetActive(false);
    }
    public void ActivateStatsMenu()
    {
        statsMenu.SetActive(true);
        trophiesMenu.SetActive(false);
    }

}
