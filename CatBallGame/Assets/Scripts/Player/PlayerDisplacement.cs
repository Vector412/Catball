using UnityEngine;
public class PlayerDisplacement : MonoBehaviour
{
    [SerializeField][Range(-5, 5)] float speed;
	private void Update() => transform.Translate(Vector3.right * Time.deltaTime * speed);
}
