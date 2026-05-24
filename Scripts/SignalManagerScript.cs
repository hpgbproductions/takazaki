using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalManagerScript : MonoBehaviour
{
    private void Awake()
    {
        ServiceProvider.Instance.DevConsole.RegisterCommand<string, SignalScript.Aspects, int>("SetSignalAspect", SetSignalAspect);
        ServiceProvider.Instance.DevConsole.RegisterCommand<string, SignalScript.Aspects, int>("SetSignalGroupAspect", SetSignalGroupAspects);
    }

    public SignalScript FindSignal(string name)
    {
        Transform childTransform = transform.Find(name);
        if (childTransform == null)
        {
            Debug.LogError($"SignalManagerScript.FindSignal: No signal with the name {name}.");
            return null;
        }
        else
        {
            return childTransform.GetComponent<SignalScript>();
        }
    }

    /// <summary>
    /// Set the maximum permissible aspect of the signal.
    /// </summary>
    /// <param name="name">Signal object name.</param>
    /// <param name="aspect"></param>
    /// <returns>1 if the operation was successful, otherwise 0.</returns>
    public int SetSignalAspect(string name, SignalScript.Aspects aspect)
    {
        SignalScript signal = FindSignal(name);
        if (signal == null)
        {
            Debug.LogError($"SignalManagerScript.SetSignalAspect: No signal with the name {name}.");
            return 0;
        }
        else
        {
            signal.MaxPermissions = aspect;
            return 1;
        }
    }

    /// <summary>
    /// Set the maximum permissible aspect of all signals that are children of the named object.
    /// </summary>
    /// <param name="groupName">Name of the GameObject containing the signals.</param>
    /// <param name="aspect"></param>
    /// <returns>The number of signals in the group if the operation was successful, otherwise 0.</returns>
    public int SetSignalGroupAspects(string groupName, SignalScript.Aspects aspect)
    {
        Transform signalGroupTransform = transform.Find(groupName);
        if (signalGroupTransform == null)
        {
            Debug.LogError($"SignalManagerScript.SetSignalGroupAspects: No signal group GameObject with the name {groupName}.");
            return 0;
        }
        else
        {
            SignalScript[] signals = signalGroupTransform.GetComponentsInChildren<SignalScript>();
            foreach (SignalScript signal in signals)
            {
                signal.MaxPermissions = aspect;
            }
            return signals.Length;
        }
    }
}
