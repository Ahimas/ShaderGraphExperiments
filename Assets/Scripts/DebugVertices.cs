using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class DebugVertices : MonoBehaviour {

	private Vector3[] _vertices;

	private void OnDrawGizmos()
	{
		_vertices ??= GetComponent<MeshFilter>().sharedMesh.vertices;

		foreach (Vector3 v in _vertices)
		{
			Vector3 vertWorldPosition = transform.position + v;
			Vector3 cameraViewPosition = SceneView.GetAllSceneCameras()[0].WorldToViewportPoint(vertWorldPosition);

			UnityEditor.Handles.Label(vertWorldPosition,
				"ObjectSpace: " + v + "\nWorldSpace: " + vertWorldPosition + "\nViewSpace: " + cameraViewPosition);
		}
	}
}
