using UnityEngine;
public class BuildCamMotor
{
    GameObject m_camera;
    Vector3 m_moveRange;
    private float m_moveSpeed;

    public BuildCamMotor (GameObject cam, Vector3 range,float speed)
    {
        m_camera = cam;
        m_moveRange = range;
        m_moveSpeed = speed;
    }


    public void Move(Vector2 input)
    {
        Vector3 dir = new Vector3(input.x, 0, input.y);

        //ビルドモードカメラ移動.
        m_camera.transform.position += m_moveSpeed * Time.deltaTime * dir;

        //移動範囲制限.
        Vector3 currentPos = m_camera.transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, -m_moveRange.x, m_moveRange.x);
        currentPos.z = Mathf.Clamp(currentPos.z, -m_moveRange.z, m_moveRange.z);

        m_camera.transform.position=currentPos;
    }
}
