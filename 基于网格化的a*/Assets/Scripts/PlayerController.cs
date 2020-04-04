using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject grid;
    public float speed = 0.2f;
    private List<Vector3> path = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        transform.SetPositionAndRotation(grid.GetComponent<Grid>().FromVectorToPosition(new Vector2Int(0, 1)), Quaternion.identity);
        transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, 1), Quaternion.identity);
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            path = grid.GetComponent<Grid>().FindWay(transform.position, mousePosition);
        }
        if (path.Count != 0)
        {
            if (Mathf.Abs(transform.position.x - path[path.Count - 1].x) > 0.001 || Mathf.Abs(transform.position.y - path[path.Count - 1].y) > 0.001)
            {
                Vector2 temp = Vector2.MoveTowards(transform.position, path[path.Count - 1], speed);
                GetComponent<Rigidbody2D>().MovePosition(temp);
            }
            else
            {
                path.RemoveAt(path.Count - 1);
            }

        }
    }
}
