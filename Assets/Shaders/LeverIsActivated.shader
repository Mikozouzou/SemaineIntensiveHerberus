// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-7857-OUT;n:type:ShaderForge.SFN_Tex2d,id:9019,x:31959,y:32424,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:_node_9019,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d25860975db82064299547e6adec9a66,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:6038,x:31907,y:32652,ptovrint:False,ptlb:CurrentState,ptin:_CurrentState,varname:node_6038,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07586229,c2:1,c3:0,c4:1;n:type:ShaderForge.SFN_Add,id:5261,x:32153,y:32575,varname:node_5261,prsc:2|A-9019-RGB,B-6038-RGB;n:type:ShaderForge.SFN_Multiply,id:7857,x:32397,y:32768,varname:node_7857,prsc:2|A-5261-OUT,B-618-OUT;n:type:ShaderForge.SFN_Slider,id:618,x:31878,y:32867,ptovrint:False,ptlb:EmissiveValue,ptin:_EmissiveValue,varname:node_618,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5752876,max:1;proporder:9019-6038-618;pass:END;sub:END;*/

Shader "Shader Forge/LeverIsActivated" {
    Properties {
        _Texture ("Texture", 2D) = "white" {}
        _CurrentState ("CurrentState", Color) = (0.07586229,1,0,1)
        _EmissiveValue ("EmissiveValue", Range(0, 1)) = 0.5752876
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float4 _CurrentState;
            uniform float _EmissiveValue;
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
////// Lighting:
////// Emissive:
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 emissive = ((_Texture_var.rgb+_CurrentState.rgb)*_EmissiveValue);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
