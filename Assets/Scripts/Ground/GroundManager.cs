using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : Singleton<GroundManager>
{
    public RollType rollType = RollType.XZ;
    public Transform playerTrans;
    [Range(0, 0.1f)] public float rollStrength = 0.01f;

    private void SetShaderProperties()
    {
        if (rollType == RollType.Z)
            Shader.EnableKeyword("GroundRollOnlyZ");
        else
            Shader.DisableKeyword("GroundRollOnlyZ");

        if (GameManager.Inst == null)
            return;
        if (GameManager.Inst.playerTrans == null)
            return;
        Shader.SetGlobalVector("_PlayerPos", GameManager.Inst.playerTrans.position);
        Shader.SetGlobalFloat("_RollStrength", rollStrength);
    }

    private void OnValidate()
    {
        SetShaderProperties();
    }

    void Update()
    {
        SetShaderProperties();
    }
}
