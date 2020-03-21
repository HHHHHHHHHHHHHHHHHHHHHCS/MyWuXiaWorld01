using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ScreenBlack : ScriptableRendererFeature
{
    public static bool enableScreenBlack;

    class ScreenBlackPass : ScriptableRenderPass
    {
        private const string screenBlackShader = "MyWuXia/Screen/S_ScreenBlack";

        private Dictionary<string, Material> Materials = new Dictionary<string, Material>();
        public Material GetMaterial(string shaderName)
        {
            Material material;
            if (Materials.TryGetValue(shaderName, out material))
            {
                return material;
            }
            else
            {
                Shader shader = Shader.Find(shaderName);

                if (shader == null)
                {
                    Debug.LogError("Shader not found (" + shaderName + "), check if missed shader is in Shaders folder if not reimport this package. If this problem occurs only in build try to add all shaders in Shaders folder to Always Included Shaders (Project Settings -> Graphics -> Always Included Shaders)");
                }

                Material NewMaterial = new Material(shader);
                NewMaterial.hideFlags = HideFlags.HideAndDontSave;
                Materials.Add(shaderName, NewMaterial);
                return NewMaterial;
            }
        }


        private int screenCopyID;

        // This method is called before executing the render pass.
        // It can be used to configure render targets and their clear state. Also to create temporary render target textures.
        // When empty this render pass will render to the active camera render target.
        // You should never call CommandBuffer.SetRenderTarget. Instead call <c>ConfigureTarget</c> and <c>ConfigureClear</c>.
        // The render pipeline will ensure target setup and clearing happens in an performance manner.
        public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
        {
            screenCopyID = Shader.PropertyToID("_ScreenCopyTexture");
            cmd.GetTemporaryRT(screenCopyID, cameraTextureDescriptor);
        }

        // Here you can implement the rendering logic.
        // Use <c>ScriptableRenderContext</c> to issue drawing commands or execute command buffers
        // https://docs.unity3d.com/ScriptReference/Rendering.ScriptableRenderContext.html
        // You don't have to call ScriptableRenderContext.submit, the render pipeline will call it at specific points in the pipeline.
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (enableScreenBlack)
            {
                CommandBuffer buffer = CommandBufferPool.Get("ScreenBlack");
                buffer.name = "ScreenBlack";

                buffer.Blit(BuiltinRenderTextureType.CurrentActive, screenCopyID);

                Material VignetteMaterial = GetMaterial(screenBlackShader);
                buffer.Blit(screenCopyID, BuiltinRenderTextureType.CurrentActive, VignetteMaterial, 0);

                context.ExecuteCommandBuffer(buffer);
                CommandBufferPool.Release(buffer);
            }
        }

        /// Cleanup any allocated resources that were created during the execution of this render pass.
        public override void FrameCleanup(CommandBuffer cmd)
        {
            cmd.ReleaseTemporaryRT(screenCopyID);
        }


    }

    ScreenBlackPass m_ScriptablePass;

    public override void Create()
    {
        m_ScriptablePass = new ScreenBlackPass();

        // Configures where the render pass should be injected.
        m_ScriptablePass.renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
    }

    // Here you can inject one or multiple render passes in the renderer.
    // This method is called when setting up the renderer once per-camera.
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(m_ScriptablePass);
    }
}


