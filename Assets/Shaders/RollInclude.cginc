uniform float3 _PlayerPos;
uniform float _RollStrength;

inline float4 GetZRollDist(float3 worldPos)
{
    return pow(worldPos.z - _PlayerPos.z, 2);
}

inline float4 GetXZRollDist(float3 worldPos)
{
    float2 tempFloat2 = pow(worldPos.xz - _PlayerPos.xz, 2);
    return tempFloat2.x + tempFloat2.y;
}

inline float4 GetFixedRollClipPos(float4 objVertex) {
    float3 worldPos = mul(unity_ObjectToWorld, objVertex);
#ifdef GroundRollOnlyZ
    float dist2Player = GetZRollDist(worldPos);
#else
    float dist2Player = GetXZRollDist(worldPos);
#endif
    worldPos.y -= dist2Player * _RollStrength;

    return mul(UNITY_MATRIX_VP, float4(worldPos, 1));
}