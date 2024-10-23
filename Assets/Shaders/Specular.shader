Shader"Custom/Specular"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MetallicTex ("Metallic (r)", 2D) = "white" {}
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _SpecColor("Specular", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "Queue"="Geometry" }
        CGPROGRAM
        #pragma surface surf StandardSpecular

        sampler2D _MetallicTex;
        half _Metallic;
        fixed4 _Color;

        struct Input
        {
            float2 uv_MetallicTex;
        };

        void surf(Input IN, inout SurfaceOutputStandardSpecular o)
        {
            o.Albedo = _Color.rgb;
            o.Specular = _Metallic;
            o.Smoothness = tex2D(_MetallicTex, IN.uv_MetallicTex).r;
        }
        ENDCG
    }
    FallBack"Diffuse"
}
