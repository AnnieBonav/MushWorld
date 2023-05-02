Shader "Unlit/Test"
{
    Properties
    {
        _SignalColor("Color", Color) = (1,1,1,1)
        _FresnelPower("Fresnel Power", float) = 1.0
    }
        SubShader
    {
        Tags {
            "RenderType" = "Opaque"
            "Queue" = "Transparent"
        }

        Pass
        {
            Cull Off
            ZWrite Off
            ZTest LEqual
            Blend One One // additive

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            #define TAU 6.28318530718

            float4 _SignalColor;
            float _FresnelPower;

            struct MeshData
            {
                float4 vertex : POSITION;
                float3 normals : NORMAL;
                float uv0 : TEXCOORD0;
            };

            struct Interpolators
            {
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
                float3 viewDir : TEXCOORD1;
                float2 uv : TEXCOORD2;
            };

            float GetWave(float2 uv) {
                float2 uvsCentered = uv * 2 - 1;
                float radialDistance = length(uvsCentered);

                float wave = cos((radialDistance - _Time.y * 0.2) * TAU * 5) * 0.5 + 0.5;
                return wave;
            }

            Interpolators vert(MeshData v)
            {
                Interpolators o;

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normals);
                o.viewDir = WorldSpaceViewDir(v.vertex);
                o.uv = v.uv0;
                return o;
            }

            fixed4 frag(Interpolators i) : SV_Target
            {
                // Fresnel
                float fresnel = pow((1.0 - saturate(dot(normalize(i.normal), normalize(i.viewDir)))), _FresnelPower);
                float4 color = fresnel * _SignalColor;

                return(color);
            }
            ENDCG
        }
    }
}