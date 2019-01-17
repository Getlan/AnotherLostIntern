using UnityEngine.Rendering.PostProcessing;
using UnityEditor.Rendering.PostProcessing;

[PostProcessEditor(typeof(Grayscale))]
public sealed class GrayscaleEditor : PostProcessEffectEditor<Grayscale>
{
    SerializedParameterOverride m_Blend;
    SerializedParameterOverride m_Radius;

    public override void OnEnable()
    {
        m_Blend = FindParameterOverride(x => x.blend);
        m_Radius = FindParameterOverride(x => x.radius);
    }

    public override void OnInspectorGUI()
    {
        PropertyField(m_Blend);
        PropertyField(m_Radius);
    }
}