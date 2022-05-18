using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanOpener : MonoBehaviour
{
    public GameObject UpgradePan;

    public void OpenUpgradePan()
    {
        if (UpgradePan != null)
        {
            UpgradePan.SetActive(true);
        }
    }
    
    public void CloseUpgradePan()
    {
        if (UpgradePan != null)
        {
            UpgradePan.SetActive(false);
        }
    }
}
