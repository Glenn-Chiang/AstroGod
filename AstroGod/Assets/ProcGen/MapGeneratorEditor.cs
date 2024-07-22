using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapGenerator generator = (MapGenerator)target;

        // Draws the default inspector and checks if any values were changed in the inspector
        if (DrawDefaultInspector() && generator.autoUpdate)
        {
            generator.Generate();
        }

        // Button to generate map
        if (GUILayout.Button("Generate"))
        {
            generator.Generate();
        }
    }
}