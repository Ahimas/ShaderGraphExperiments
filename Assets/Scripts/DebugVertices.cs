using UnityEngine;

public class DebugVertices : MonoBehaviour {

	private Vector3[] _vertices;

	private void OnDrawGizmos()
	{
		_vertices ??= GetComponent<MeshFilter>().sharedMesh.vertices;

		foreach (Vector3 v in _vertices)
            UnityEditor.Handles.Label(transform.position + v, "v: " + v.ToString());
	}
}
