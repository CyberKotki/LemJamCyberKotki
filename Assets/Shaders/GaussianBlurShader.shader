Shader "Custom/GaussianBlurShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurStrength ("Blur Strength", Range(0, 10)) = 1.0
        _Color ("Color", Color) = (0, 0, 0, 0.5) // Semi-transparent black
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "GaussianBlur.hlsl" // Include the downloaded GaussianBlur file

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _BlurStrength;
            float4 _Color;

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float4 blurredColor = GaussianBlur(_MainTex, i.uv, _BlurStrength);
                return blurredColor * _Color;
            }
            ENDHLSL
        }
    }
}
