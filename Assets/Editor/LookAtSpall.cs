using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SomeScript))]
public class SomeScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.HelpBox("This is a help box", MessageType.Info);
    }

void cub()
    {
        Vector3 position = new Vector3(0, 0, 0);
        for (int i = 0; i < 10; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = position;
            position += new Vector3(5, 0, 0);
        }
    }
    public class SomeScript : MonoBehaviour
    {
        public int level;
        public float health;
        public Vector3 target;
    }
}
