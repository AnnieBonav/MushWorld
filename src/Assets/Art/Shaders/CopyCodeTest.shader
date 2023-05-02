Shader "Unlit/CopyCodeTest"
{
    Properties
    {
        //_MainTex ("Texture", 2D) = "white" {}
        _ColorA("Color A", Color) = (1,1,1,1)
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            //sampler2D _MainTex;
            float4 _ColorA;
            //float4 _MainTex_ST;

            struct MeshData
            {
                float4 vertex : POSITION;
                float2 uv0 : TEXCOORD0;
            };

            struct Interpolators
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD2;
            };

            Interpolators vert(MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv0;
                return o;
            }

            half4 frag(Interpolators i) : SV_Target
            {
                float4 please = float4(255,0,0,1);
                //float4 col = tex2D(_MainTex, i.uv);
                half4 color = _ColorA * 1;
                return (please);
                //return col;
            }
            ENDCG
        }
    }
}
