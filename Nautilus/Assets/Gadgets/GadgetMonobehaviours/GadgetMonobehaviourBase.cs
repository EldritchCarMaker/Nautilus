using UnityEngine;

namespace Nautilus.Assets.Gadgets.GadgetMonobehaviours;
/// <summary>
/// A class to be inherited from to add gadgets to prefabs as components
/// </summary>
[RequireComponent(typeof(ICustomPrefab))]//REPLACE WITH CUSTOM PREFAB COMPONENT IN FUTURE. DO NOT USE THIS
public abstract class GadgetMonobehaviourBase : MonoBehaviour
{
    private ICustomPrefab _prefab;

    /// <summary>
    /// Gets the Custom Prefab attached to the object
    /// </summary>
    protected ICustomPrefab Prefab
    {
        get
        {
            if(_prefab == null) _prefab = GetComponent<ICustomPrefab>();//REPLACE WITH CUSTOM PREFAB COMPONENT IN FUTURE. DO NOT USE THIS
            return _prefab;
        }
    }

    /// <summary>
    /// Called when its time to add the respective gadget to the prefab
    /// </summary>
    protected abstract void AddGadget();
}
