using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowOpener : MonoBehaviour
{
    public GameObject leaguePanel;

    public GameObject fighterInfoPanel;

    public GameObject leagueAccount;

    public Animation anim;

    public void OpenLeagueAccount()
    {
         if (leagueAccount != null)
        {
            bool isActive = leagueAccount.activeSelf;
            leagueAccount.SetActive(!isActive);
            //leaguePanel.SetActive(false);
        }
    }


    public void OpenLeaguePanel()
    {
        if (leaguePanel != null)
        {
            bool isActive = leaguePanel.activeSelf;
            leaguePanel.SetActive(!isActive);
            fighterInfoPanel.SetActive(false);
        }
    }

    public void OpenFighterInfo()
    {
         if (fighterInfoPanel != null)
        {
            bool isActive = fighterInfoPanel.activeSelf;
            fighterInfoPanel.SetActive(!isActive);
        }
    }

    public void leftPanelAnimation() // Пока что не работает
    {
        anim = GetComponent<Animation>();
        foreach (AnimationState state in anim)
        {
            state.speed = 0.5F;
        }
    }
    
}
