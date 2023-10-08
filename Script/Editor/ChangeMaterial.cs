using UnityEngine;
using UnityEditor;

public class ChangeMaterial : MonoBehaviour
{

    [MenuItem("Tools/changeMaterial")]
    public static void change()
    {
        Object[] m_objects = Selection.GetFiltered(typeof(Material), SelectionMode.DeepAssets);//从所有选择的对象中挑选出材质球

        if (m_objects.Length != 1)//不能有多个材质球存在，我们只替换成一个材质球
        {
            Debug.Log("选择的材质不唯一");
            return;
        }
        foreach (GameObject go in Selection.gameObjects)//遍历所有选择的对象，替换shader
        {
            FindMater(go, m_objects[0] as Material);
        }

        Debug.Log("Complete! ");
    }


    public static void FindMater(GameObject go, Material m)
    {
        if (go.GetComponent<MeshRenderer>() != null)//替换所选对象的材质球
        {
            go.GetComponent<MeshRenderer>().material = m;
        }

        foreach (Transform child in go.transform)//替换所选对象的子物体的材质球
        {
            FindMater(child.gameObject, m);

            if (child.GetComponent<MeshRenderer>() != null)
            {
                child.GetComponent<MeshRenderer>().material = m;
            }
        }
    }

}