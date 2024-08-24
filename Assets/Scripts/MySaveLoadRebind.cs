using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MySaveLoadRebind : MonoBehaviour
{
    public InputActionAsset actions;
    public GatherInput player;

#if BINDING_PERSISTENTES_CON_CSHARP_CLASS_GENERATED
    public void OnEnable()
    {
        var rebinds = PlayerPrefs.GetString("rebinds");
        if (!string.IsNullOrEmpty(rebinds))
            actions.LoadBindingOverridesFromJson(rebinds);
    }

    public void OnDisable()
    {
        var rebinds = actions.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString("rebinds", rebinds);

        player?.ActionsResetAndLoad();
    }
#endif
}
