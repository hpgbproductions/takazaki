using System.Collections;
using System.Collections.Generic;
using Jundroo.SimplePlanes.ModTools.Events;
using UnityEngine;

public class SetWaterLevelScript : MonoBehaviour
{
    private int FrameInterval = 500;
    private int FramesRemaining;

    private float ChangeoverPoint = -5750f;

    private void Start()
    {
        ServiceProvider.Instance.GameState.MapLocationChanged += OnLocationChanged;
        FramesRemaining = FrameInterval;
    }

    private void UpdateWaterLevel()
    {
        float zpos = ServiceProvider.Instance.PlayerAircraft.MainCockpitPosition.z + ServiceProvider.Instance.GameWorld.FloatingOriginOffset.z;

        if (zpos > ChangeoverPoint)
        {
            ServiceProvider.Instance.GameWorld.SeaLevel = 160;
        }
        else
        {
            ServiceProvider.Instance.GameWorld.SeaLevel = 0;
        }
    }

    private void FixedUpdate()
    {
        FramesRemaining--;

        if (FramesRemaining == 0)
        {
            UpdateWaterLevel();
            FramesRemaining = FrameInterval;
        }
    }

    private void OnLocationChanged(object sender, MapLocationChangedEventArgs a)
    {
        UpdateWaterLevel();
        FramesRemaining = FrameInterval;
    }
}
