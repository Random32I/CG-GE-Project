Shader "Custom/Ambient"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MetallicTex ("Metallic (r)", 2D) = "white" {}
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "Queue"="Geometry" }
        CGPROGRAM
        #pragma surface surf Standard 

        sampler2D _MetallicTex;
        half _Metallic;
        fixed4 _Color;

        struct Input
        {
            float2 uv_MetallicTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = _Color.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = tex2D(_MetallicTex, IN.uv_MetallicTex).r;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
