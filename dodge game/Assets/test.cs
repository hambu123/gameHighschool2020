﻿using UnityEditor;
using UnityEngine;

public class Test : EditorWindow
{
    // Start is called before the first frame update
    [MenuItem("Window/Test")]

    static void Init()
    {
        Test window = (Test)EditorWindow.GetWindow(typeof(Test));
        window.Show();
    }

    // Update is called once per frame
    void OnGUI()
    {
        Handles.color = Color.red;
        Handles.DrawRectangle(0, new Vector3(200, 200, 0), Quaternion.identity, 100);
        Handles.DrawSolidDisc(new Vector3(200, 200, 0), Vector3.forward, 100);
        Handles.DrawSolidDisc(new Vector3(150, 150, 0), Vector3.forward, 50);
        Handles.DrawSolidDisc(new Vector3(250, 150, 0), Vector3.forward, 50);
    }
}
