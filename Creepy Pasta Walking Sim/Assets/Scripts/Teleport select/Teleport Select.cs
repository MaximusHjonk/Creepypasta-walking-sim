using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportSelect : MonoBehaviour
{
    public GameObject selectionPanel;
    public Camera mainCamera;
    public Image crosshair;
    public List<NavigationWaypoint> listOfWaypoints;


    public void MoveToTeleport1()
    {
        listOfWaypoints[0].Activate();
    }
    public void MoveToTeleport2()
    {
        listOfWaypoints[1].Activate();

    }
    public void MoveToTeleport3()
    {
        listOfWaypoints[2].Activate();

    }
    public void MoveToTeleport4()
    {
        listOfWaypoints[3].Activate();

    }
    public void MoveToTeleport5()
    {
        listOfWaypoints[4].Activate();

    }
    public void MoveToTeleport6()
    {
        listOfWaypoints[5].Activate();

    }
}
