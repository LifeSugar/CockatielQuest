using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawleaf : MonoBehaviour
{

    public Mesh ShapMesh;
    public Mesh LeafMesh;
    public List<Material> mats = new List<Material>();
    // [Range(0f,1f)]
    private float LeafDensity = 1f;
    // [Range(0f,2f)]
    private float LeafSize = 0.15f;
    // [Range(0f,1f)]
    private float LeafOffset = 0;

    private List<LeafData> LeafDatas;
    
    
    List<List<Matrix4x4>> matrix4X4s = new List<List<Matrix4x4>>();
    List<List<Vector4>> normals = new List<List<Vector4>>();
    List<List<float>> speedShift = new List<List<float>>(); 


    // Start is called before the first frame update
    void Start()
    {
        InitLeaf();
    }

    private void InitLeaf()
    {
        LeafDatas = new List<LeafData>();
        for (int i = 0; i< ShapMesh.vertices.Length; i++)
        {
            float random = Random.Range(0f,1f);
            if (LeafDensity < random)
                continue;
            Vector3 pos = transform.TransformPoint(ShapMesh.vertices[i]);
            Vector3 normal = transform.TransformPoint(ShapMesh.normals[i]) - transform.position;
            Quaternion quaternion = Quaternion.Euler(0,0,Random.Range(0,360));
            float size = Random.Range(0, mats.Count);
            int matIndex = Random.Range(0, mats.Count);
            float speedOffset = Random.Range(0f,4f);

            LeafData data = new LeafData() { pos = pos, normal = normal, Size = size, matIndex = matIndex, speedOffset = speedOffset, quaternion = quaternion};
            LeafDatas.Add(data);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Drawleafs();
    }

    private void Drawleafs()
    {
        // List<List<Matrix4x4>> matrix4X4s = new List<List<Matrix4x4>>();
        // List<List<Vector4>> normals = new List<List<Vector4>>();
        // List<List<float>> speedShift = new List<List<float>>();
        for (int i = 0; i < mats.Count; i++){
            matrix4X4s.Add(new List<Matrix4x4>());
            normals.Add(new List<Vector4>());
            speedShift.Add(new List<float>());
        }

        foreach (LeafData data in LeafDatas){
            int index = data.matIndex;
            Vector3 pos = data.pos + data.normal * LeafOffset;
            Vector3 scale = Vector3.one * data.Size * LeafSize;
            Matrix4x4 matrix4X4 = Matrix4x4.TRS(pos, data.quaternion, scale);
            matrix4X4s[index].Add(matrix4X4);
            normals[index].Add(data.normal);
            speedShift[index].Add(data.speedOffset);
            if (matrix4X4s[index].Count >= 1023){
                MaterialPropertyBlock block = new MaterialPropertyBlock();
                block.SetVectorArray("_normal", normals[index].ToArray());
                block.SetFloatArray("_speedOffset", speedShift[index].ToArray());
                Graphics.DrawMeshInstanced(LeafMesh, 0, mats[index], matrix4X4s[index].ToArray(), 
                    matrix4X4s[index].Count, block, UnityEngine.Rendering.ShadowCastingMode.Off, false);
                matrix4X4s[index].Clear();
                normals[index].Clear();
                speedShift[index].Clear();
            }

        }

        for (int i = 0; i < mats.Count; i++)
        {
            int index = i;
            if(matrix4X4s[index].Count == 0)
                continue;
            MaterialPropertyBlock block = new MaterialPropertyBlock();
            block.SetVectorArray("_normal", normals[index].ToArray());
            block.SetFloatArray("_speedOffset", speedShift[index].ToArray());
            Graphics.DrawMeshInstanced(LeafMesh, 0, mats[index], matrix4X4s[index].ToArray(), 
                matrix4X4s[index].Count, block, UnityEngine.Rendering.ShadowCastingMode.Off, false);
            matrix4X4s[index].Clear();
            normals[index].Clear();
            speedShift[index].Clear();
        }
    }
    public struct LeafData
    {
        public Vector3 pos;
        public Vector3 normal;
        public Quaternion quaternion;
        public float Size;
        public int matIndex;
        public float speedOffset;

    }
}
