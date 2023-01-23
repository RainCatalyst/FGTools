using UnityEngine;

namespace Asteroids
{
    public class GameBounds : MonoBehaviour
    {
        public Vector2 GetRandomEdgePosition()
        {
            int edge = Random.Range(0, 2);
            if (edge == 0)
                return new Vector2(Random.Range(-_bounds.x, _bounds.x) * 0.5f, _bounds.y * 0.5f);
            return new Vector2(-_bounds.x * 0.5f, Random.Range(-_bounds.y, _bounds.y) * 0.5f);
        }
        
        private void Update()
        {
            foreach (Transform child in transform)
            {
                child.position = WarpPosition(child.position);
            }
        }

        private Vector2 WarpPosition(Vector2 pos)
        {
            Vector2 halfBounds = _bounds * 0.5f;
            pos.x = Mathf.Repeat(pos.x + halfBounds.x,_bounds.x) - halfBounds.x;
            pos.y = Mathf.Repeat(pos.y + halfBounds.y,_bounds.y) - halfBounds.y;
            return pos;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(Vector3.zero, _bounds);
        }

        [SerializeField]
        private Vector2 _bounds;
    }
}