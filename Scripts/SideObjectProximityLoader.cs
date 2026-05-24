using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideObjectProximityLoader : MonoBehaviour
{
    private Renderer SelfRenderer;

    private List<GameObject> AffectedChildObjects = new List<GameObject>();
    private bool ChildObjectsActive = true;

    private Vector3 LoadDistance = new Vector3(2000f, 1000f, 2000f);

    private float CheckInterval = 1f;
    private float CheckTimeRemaining = 0f;

    void Start()
    {
        SelfRenderer = gameObject.GetComponent<Renderer>();

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject obj = transform.GetChild(i).gameObject;

            // Only unload objects without colliders
            if (obj.GetComponent<Collider>() == null)
            {
                AffectedChildObjects.Add(obj);
            }
        }
    }

    void Update()
    {
        CheckTimeRemaining -= Time.unscaledDeltaTime;
        if (CheckTimeRemaining >= 0)
        {
            return;
        }
        CheckTimeRemaining = CheckInterval;

        Vector3 AircraftPosition = ServiceProvider.Instance.PlayerAircraft.MainCockpitPosition;
        Vector3 LoadPositionMin = SelfRenderer.bounds.min - LoadDistance;
        Vector3 LoadPositionMax = SelfRenderer.bounds.max + LoadDistance;

        if (LoadPositionMin.x < AircraftPosition.x && AircraftPosition.x < LoadPositionMax.x
            && LoadPositionMin.y < AircraftPosition.y && AircraftPosition.y < LoadPositionMax.y
            && LoadPositionMin.z < AircraftPosition.z && AircraftPosition.z < LoadPositionMax.z)
        {
            if (!ChildObjectsActive)
            {
                foreach (GameObject g in AffectedChildObjects)
                {
                    g.SetActive(true);
                }
                ChildObjectsActive = true;
                CheckInterval = 5f;
            }
        }
        else
        {
            if (ChildObjectsActive)
            {
                foreach (GameObject g in AffectedChildObjects)
                {
                    g.SetActive(false);
                }
                ChildObjectsActive = false;
                CheckInterval = 1f;
            }
        }
    }
}
