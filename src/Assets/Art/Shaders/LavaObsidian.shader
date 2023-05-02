Shader "Unlit/LavaObsidian"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _ColorA("Color A", Color) = (1,1,1,1)
        _Speed("River Speed", float) = 1
        _FresnelPower("Fresnel Power", float) = 1
        _WaveAmplitude("Wave Amplitude", float) = 1
        _WaveLength("Wave Length", float) = 1
        _WaveSpeed("Wave Speed", float) = 1
        _NoiceColor("Noice Color", Color) = (1,1,1,1)
    }
        SubShader
        {
            Tags {
                "RenderType" = "Opaque"
                "Queue" = "Transparent"
            }

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #define TAU 6.28318530718

                #include "UnityCG.cginc"

                sampler2D _MainTex;
                float4 _ColorA;
                float4 _MainTex_ST;
                float _Speed;
                float _FresnelPower;
                float _WaveAmplitude;
                float _WaveLength;
                float _WaveSpeed;
                float4 _NoiceColor;

                struct MeshData
                {
                    float4 vertex : POSITION;
                    float3 normals : NORMAL;
                    float2 uv0 : TEXCOORD0;
                    float3 worldPos : TEXCOORD1;
                };

                struct Interpolators
                {
                    float4 vertex : SV_POSITION;
                    float3 normal : TEXCOORD0;
                    float3 viewDir : TEXCOORD1;
                    float2 uv : TEXCOORD2;
                    float3 worldPos : TEXCOORD3;
                };

                Interpolators vert(MeshData v)
                {
                    Interpolators o;
                    o.worldPos = mul(UNITY_MATRIX_M, v.vertex);
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.viewDir = WorldSpaceViewDir(v.vertex);
                    o.uv = v.uv0;
                    o.uv.y *= _Time.y * _Speed;
                    // o.vertex.y += (cos(_Time.y * _WaveLength) * 0.5 + 0.5) * _WaveAmplitude; // Wave

                    float4 worldStuff = float4(o.worldPos.xz + _Time.y * _WaveSpeed, 0, 0);
                    float theHeight = tex2Dlod(_MainTex, worldStuff).x;
                    o.vertex.y += theHeight;
                    return o;
                }

                half4 frag(Interpolators i) : SV_Target
                {
                    // float fresnel = pow((1.0 - saturate(dot(normalize(i.normal), normalize(i.viewDir)))), _FresnelPower);
                    float4 noice = tex2D(_MainTex, float4(i.uv.x, i.uv.y / 10, 0, 0));
                    float clamped = clamp(noice, 0.2, 1);
                    float4 noiceColor = noice * _NoiceColor;
                    //return noice;
                    // return clamped;
                    return noiceColor * clamped;
                    return noiceColor * _ColorA; // Dark that gets super added between both colors
                    return lerp(_ColorA, noiceColor, i.uv.x);
                    //return col;
                }
                ENDCG
            }
        }
}
