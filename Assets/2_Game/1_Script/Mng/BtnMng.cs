using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnMng : MonoBehaviour
{
    public GameObject MobileUIGams;
    public GameObject AttackBtnGams;
    public GameObject RollinBtnGams;
    public GameObject PauseSceneGams;
    public GameObject GetInvenGams;

    public void PauseBtn()
    {
        PauseSceneGams.SetActive(true);
    }

    public void PauseExitBtn()
    {
        PauseSceneGams.SetActive(false);
    }

    public void AttackBtnDown()
    {
        if (SGameMng.I.PlayerType.Equals(PLAYERTYPE.TURTLE))
        {
            if (!SGameMng.I.PlayerSc._bPlayerDie && !SGameMng.I.PlayerSc._bSkillOn)
                SGameMng.I.PlayerSc._bAttackAccess = true;
        }
        else
        {
            if (!SGameMng.I.PlayerSc._bPlayerDie)
                SGameMng.I.PlayerSc._bAttackAccess = true;
        }
    }

    public void AttackBtnUp()
    {
        SGameMng.I.PlayerSc._bAttackAccess = false;
    }

    public void ActiveSkillBtn()
    {
        if (SGameMng.I.PlayerType.Equals(PLAYERTYPE.TURTLE))
        {
            if (!SGameMng.I.PlayerSc._bPlayerDie)
            {
                if (!SGameMng.I.PlayerSc._bSkillOn)
                {
                    SGameMng.I.PlayerSc._bSkillOn = true;
                    SGameMng.I.PlayerSc._bDmgAccess = false;
                    if (!SGameMng.I.PlayerSc._bLookRight)
                        SGameMng.I.PlayerSc._PlayerAnime.SetBool("isLSkill", true);
                    else
                        SGameMng.I.PlayerSc._PlayerAnime.SetBool("isRSkill", true);
                }
                else
                {
                    SGameMng.I.PlayerSc._bSkillOn = false;
                    SGameMng.I.PlayerSc._bDmgAccess = true;
                    if (!SGameMng.I.PlayerSc._bLookRight)
                        SGameMng.I.PlayerSc._PlayerAnime.SetBool("isLSkill", false);
                    else
                        SGameMng.I.PlayerSc._PlayerAnime.SetBool("isRSkill", false);
                }
            }
        }
        else
        {
            if (!SGameMng.I.PlayerSc._bPlayerDie)
                SGameMng.I.PlayerSc._bSkillOn = true;
        }
    }

    public void InvenCtrl()
    {
        if (GetInvenGams.activeInHierarchy)
        {
            GetInvenGams.SetActive(false);
        }
        else
        {
            GetInvenGams.SetActive(true);
        }
    }

    public void PlatformSwitchBtn()
    {
        if (!SGameMng.I.bMobileOn)
            PlatformSwtichSetActive(true);
        else
            PlatformSwtichSetActive(false);
    }

    void PlatformSwtichSetActive(bool SwitchOn)
    {
        SGameMng.I.bMobileOn = SwitchOn;
        MobileUIGams.SetActive(SwitchOn);
        AttackBtnGams.SetActive(SwitchOn);
        RollinBtnGams.SetActive(SwitchOn);
    }
}