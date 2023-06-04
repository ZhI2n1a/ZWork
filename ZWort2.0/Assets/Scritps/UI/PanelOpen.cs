using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpen : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Panel1;

    public void OpenPanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }

        if (Panel1 != null)
        {
            bool isActive = Panel1.activeSelf;
            Panel1.SetActive(!isActive);
        }
    }
}
