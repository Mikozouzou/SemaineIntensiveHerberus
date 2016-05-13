// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32155,y:32835,varname:node_3138,prsc:2|emission-2030-OUT,clip-2271-OUT;n:type:ShaderForge.SFN_TexCoord,id:2671,x:29968,y:33329,varname:node_2671,prsc:2,uv:0;n:type:ShaderForge.SFN_RemapRange,id:7377,x:30169,y:33291,varname:node_7377,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-2671-UVOUT;n:type:ShaderForge.SFN_Length,id:2791,x:30789,y:33375,varname:node_2791,prsc:2|IN-7377-OUT;n:type:ShaderForge.SFN_Color,id:5902,x:31103,y:32558,ptovrint:False,ptlb:Starting,ptin:_Starting,varname:_Starting,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:7646,x:31134,y:32725,ptovrint:False,ptlb:Ending,ptin:_Ending,varname:_Ending,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:0.006896496,c4:1;n:type:ShaderForge.SFN_Lerp,id:2030,x:31652,y:32755,varname:node_2030,prsc:2|A-5902-RGB,B-7646-RGB,T-5457-OUT;n:type:ShaderForge.SFN_Slider,id:5457,x:30433,y:32989,ptovrint:False,ptlb:LeverLoading,ptin:_LeverLoading,varname:_LeverLoading,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Floor,id:6008,x:31170,y:33497,varname:node_6008,prsc:2|IN-2791-OUT;n:type:ShaderForge.SFN_Add,id:2281,x:31223,y:33341,varname:node_2281,prsc:2|A-2791-OUT,B-2520-OUT;n:type:ShaderForge.SFN_Vector1,id:2520,x:31040,y:33392,varname:node_2520,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Floor,id:4791,x:31388,y:33337,varname:node_4791,prsc:2|IN-2281-OUT;n:type:ShaderForge.SFN_OneMinus,id:6607,x:31437,y:33497,varname:node_6607,prsc:2|IN-6008-OUT;n:type:ShaderForge.SFN_Multiply,id:2271,x:31754,y:33220,varname:node_2271,prsc:2|A-4620-OUT,B-4791-OUT,C-6607-OUT;n:type:ShaderForge.SFN_ComponentMask,id:4910,x:30368,y:33152,varname:node_4910,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-7377-OUT;n:type:ShaderForge.SFN_ArcTan2,id:4196,x:30557,y:33161,varname:node_4196,prsc:2,attp:2|A-4910-G,B-4910-R;n:type:ShaderForge.SFN_Ceil,id:4620,x:31385,y:33141,varname:node_4620,prsc:2|IN-6031-OUT;n:type:ShaderForge.SFN_Subtract,id:6031,x:31214,y:33140,varname:node_6031,prsc:2|A-5457-OUT,B-8363-OUT;n:type:ShaderForge.SFN_OneMinus,id:8363,x:30747,y:33162,varname:node_8363,prsc:2|IN-4196-OUT;proporder:5902-7646-5457;pass:END;sub:END;*/

Shader "Shader Forge/LeverLoading" {
    Properties {
        _Starting ("Starting", Color) = (1,0,0,1)
        _Ending ("Ending", Color) = (0,1,0.006896496,1)
        _LeverLoading ("LeverLoading", Range(0, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Starting;
            uniform float4 _Ending;
            uniform float _LeverLoading;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float2 node_7377 = (i.uv0*2.0+-1.0);
                float2 node_4910 = node_7377.rg;
                float node_2791 = length(node_7377);
                clip((ceil((_LeverLoading-(1.0 - ((atan2(node_4910.g,node_4910.r)/6.28318530718)+0.5))))*floor((node_2791+0.3))*(1.0 - floor(node_2791))) - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = lerp(_Starting.rgb,_Ending.rgb,_LeverLoading);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _LeverLoading;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float2 node_7377 = (i.uv0*2.0+-1.0);
                float2 node_4910 = node_7377.rg;
                float node_2791 = length(node_7377);
                clip((ceil((_LeverLoading-(1.0 - ((atan2(node_4910.g,node_4910.r)/6.28318530718)+0.5))))*floor((node_2791+0.3))*(1.0 - floor(node_2791))) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
