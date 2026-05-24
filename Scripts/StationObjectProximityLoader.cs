using System.Collections;
using System.Collections.Generic;
using Jundroo.SimplePlanes.ModTools.Events;
using UnityEngine;

public class StationObjectProximityLoader : MonoBehaviour
{
    private int FrameInterval = 500;
    private int FramesRemaining;

    [SerializeField] private float LoadDistance = 1000;

    private void Start()
    {
        ServiceProvider.Instance.GameState.MapLocationChanged += OnLocationChanged;
        FramesRemaining = FrameInterval;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, LoadDistance);
    }

    private void UpdateLoadedState()
    {
        float distance = Vector3.Distance(transform.position, ServiceProvider.Instance.PlayerAircraft.MainCockpitPosition);

        bool enable = false;
        if (distance < LoadDistance)
        {
            enable = true;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(enable);
        }
    }

    private void FixedUpdate()
    {
        FramesRemaining--;

        if (FramesRemaining == 0)
        {
            UpdateLoadedState();
            FramesRemaining = FrameInterval;
        }
    }

    private void OnLocationChanged(object sender, MapLocationChangedEventArgs a)
    {
        UpdateLoadedState();
        FramesRemaining = FrameInterval;
    }
}
