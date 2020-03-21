using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CustomInvokeOnRenderObjectCallbackPass : ScriptableRenderPass
{
    public CustomInvokeOnRenderObjectCallbackPass(RenderPassEvent evt)
    {
        renderPassEvent = evt;
    }

    /// <inheritdoc/>
    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        context.InvokeOnRenderObjectCallback();
    }
}