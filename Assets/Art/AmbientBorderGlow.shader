Shader "UI/AmbientBorderGlow"
{
    Properties
    {
        _MainTex ("Border Texture", 2D) = "white" {}
        _Color ("Glow Color", Color) = (1,0,0,1)
        _Intensity ("Glow Intensity", Float) = 2
        _PulseSpeed ("Pulse Speed", Float) = 4
        _PulseStrength ("Pulse Strength", Float) = 0.5
    }

    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Blend One One
        ZWrite Off
        Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _Color;
            float _Intensity;
            float _PulseSpeed;
            float _PulseStrength;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float alpha = tex2D(_MainTex, i.uv).a;

                float pulse = sin(_Time.y * _PulseSpeed) * 0.5 + 0.5;
                pulse = lerp(1, pulse, _PulseStrength);

                return _Color * alpha * _Intensity * pulse;
            }
            ENDCG
        }
    }
}
