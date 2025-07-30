Shader "Unlit/SnowHeightMap"
{
    Properties
    {
        _DrawPosition ("Draw Position", Vector) = (-1, -1, 0, 0)
    }

    SubShader
    {
        Lighting Off
        Blend One Zero
        
        Pass
        {
            CGPROGRAM
            
            #include "UnityCustomRenderTexture.cginc"
            
            #pragma vertex CustomRenderTextureVertexShader
            #pragma fragment frag
            #pragma target 3.0
            
            float4 _DrawPosition;
            
            float4 frag(v2f_customrendertexture IN) : COLOR
            {
                float4 color = tex2D(_SelfTexture2D, IN.localTexcoord.xy);
                float4 draw_color = smoothstep(0, 0.2, distance(IN.localTexcoord.xy, _DrawPosition));
                
                return min(color, draw_color);
            }
            
            ENDCG
        }
    }
}
