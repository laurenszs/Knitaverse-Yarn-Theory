Shader "Unlit/TESTING"
{
    //https://www.youtube.com/watch?v=YCi4BnnQV2s
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Tintcolor("Tint Color", color) = (1,1,1,1)
        _Transparency("Transparency", Range(0.0,0.5)) = 0.25
    }
    SubShader
    {
        Tags
        {
            "Queue" = "Transparnet" "RenderType"="Opaque"
        }
        LOD 100
        Zwrite Off
        blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Tintcolor;
            float _Transparency;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv) * _Tintcolor;
                col.a = _Transparency;
                return col;
            }
            ENDCG
        }
    }
}