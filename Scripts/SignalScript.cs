using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalScript : MonoBehaviour
{
    public enum Aspects
    {
        R = 0,
        YY = 25,
        Y = 55,
        YG = 75,
        G = 95
    };

    public enum Styles
    {
        T5,     // YYRGY
        T4F,    // YYRG-    no YY
        T4S,    // -YRGY    no YG
        T3      // -YRG-
    };

    private static Dictionary<Aspects, Aspects> SignalCauseEffect(Aspects if_r, Aspects if_yy, Aspects if_y, Aspects if_yg, Aspects if_g)
    {
        return new Dictionary<Aspects, Aspects>()
        {
            // If the next signal displays the left-side aspect (dict key),
            // then this signal will display the right-side aspect (dict value)
            { Aspects.R, if_r },
            { Aspects.YY, if_yy },
            { Aspects.Y, if_y },
            { Aspects.YG, if_yg },
            { Aspects.G, if_g }
        };
    }

    public static Dictionary<Styles, Dictionary<Aspects, Aspects>> ThisSignalAspect = new Dictionary<Styles, Dictionary<Aspects, Aspects>>()
    {
        { Styles.T5,  SignalCauseEffect(Aspects.YY, Aspects.Y, Aspects.YG, Aspects.G, Aspects.G) },
        { Styles.T4F, SignalCauseEffect(Aspects.Y, Aspects.Y, Aspects.YG, Aspects.G, Aspects.G) },
        { Styles.T4S, SignalCauseEffect(Aspects.YY, Aspects.Y, Aspects.G, Aspects.G, Aspects.G) },
        { Styles.T3,  SignalCauseEffect(Aspects.Y, Aspects.Y, Aspects.G, Aspects.G, Aspects.G) }
    };

    private void SetBulbs(bool y1, bool y2, bool r, bool g, bool y3, float range)
    {
        if (BulbYellow1 != null)
        {
            BulbYellow1.enabled = y1;
            BulbYellow1.range = range;
        }
        if (BulbYellow2 != null)
        {
            BulbYellow2.enabled = y2;
            BulbYellow2.range = range;
        }
        if (BulbRed != null)
        {
            BulbRed.enabled = r;
            BulbRed.range = range;
        }
        if (BulbGreen != null)
        {
            BulbGreen.enabled = g;
            BulbGreen.range = range;
        }
        if (BulbYellow3 != null)
        {
            BulbYellow3.enabled = y3;
            BulbYellow3.range = range;
        }
    }

    // Options
    public SignalScript NextSignal;
    public Styles SignalStyle;
    public Aspects MaxPermissions;

    // Lights
    public Light BulbYellow1;
    public Light BulbYellow2;
    public Light BulbRed;
    public Light BulbGreen;
    public Light BulbYellow3;

    // Status
    [HideInInspector] public Aspects CurrentAspect = Aspects.R;

    private void Start()
    {
    }

    private void Update()
    {
        // Check the current aspect according to signal style and next signal
        // If there is no next signal, use the permission limiter to set signal
        if (NextSignal == null)
        {
            CurrentAspect = Aspects.G;
        }
        else
        {
            CurrentAspect = ThisSignalAspect[SignalStyle][NextSignal.CurrentAspect];
        }

        // Apply permission limiter
        if (CurrentAspect > MaxPermissions)
        {
            CurrentAspect = MaxPermissions;
        }

        // Size of lights (not using GameCamera.CameraPosition since it has null ref problem)
        Vector3 relativePositionToCamera = transform.InverseTransformVector(ServiceProvider.Instance.PlayerAircraft.MainCockpitPosition - transform.position);
        float lightSize = Mathf.Lerp(0.2f, 2.0f, Mathf.InverseLerp(-20f, -200f, relativePositionToCamera.z));

        // Update lights
        switch (CurrentAspect)
        {
            case Aspects.G:
                SetBulbs(false, false, false, true, false, lightSize);
                break;
            case Aspects.YG:
                SetBulbs(true, false, false, true, false, lightSize);
                break;
            case Aspects.Y:
                SetBulbs(false, true, false, false, false, lightSize);
                break;
            case Aspects.YY:
                SetBulbs(false, true, false, false, true, lightSize);
                break;
            case Aspects.R:
                SetBulbs(false, false, true, false, false, lightSize);
                break;
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (NextSignal != null)
        {
            Gizmos.color = Color.HSVToRGB(Mathf.Min(Vector3.Distance(transform.position, NextSignal.transform.position) / 1000f, 0.833f), 1, 1);
            Gizmos.DrawLine(transform.position, NextSignal.transform.position);
        }
    }
}
