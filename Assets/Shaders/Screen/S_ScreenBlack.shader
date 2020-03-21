Shader "MyWuXia/Screen/S_ScreenBlack"
{
    Properties
    {
        _MainTex ("Source", 2D) = "white" { }
    }
    
    
    HLSLINCLUDE
    #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
    ENDHLSL
    
    SubShader
    {
        
        pass
        {
            HLSLPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag
            
            struct a2v
            {
                float3 vertex: POSITION;
                float2 uv: TEXCOORD0;
            };
            
            struct v2f
            {
                float4  pos: SV_POSITION;
                float2	uv: TEXCOORD0;
            };
            
            
            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            
            v2f vert(a2v v)
            {
                v2f o = (v2f)0;
                o.pos = TransformObjectToHClip(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            float4 frag(v2f i): SV_TARGET
            {
                float4 col = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);
                return col;
            }
            ENDHLSL
            
        }
    }
}
