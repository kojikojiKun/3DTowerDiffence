using UnityEngine;
public class BuildCamMotor
{
    GameObject m_camera;
    Vector3 m_moveRange;
    LayerMask m_groundMask;
    private float m_moveSpeed;
    private float m_minDistance = 5f;
    private float m_maxDistance = 30f;
    private float m_zoomSpeed = 10f;
    private float m_currentDistance = 15f;

    public BuildCamMotor (GameObject cam, Vector3 range,float speed,LayerMask mask)
    {
        m_camera = cam;
        m_moveRange = range;
        m_moveSpeed = speed;
        m_groundMask = mask;
    }

    public void Move(Vector2 input)
    {
        Vector3 dir = new Vector3(input.x, 0, input.y);

        //ビルドモードカメラ移動.
        m_camera.transform.position += m_moveSpeed * Time.deltaTime * dir;

        MoveRangeCollect();
    }

    void MoveRangeCollect()
    {
        float zoomFactor = (m_currentDistance - m_minDistance) / (m_maxDistance - m_minDistance);
        Vector3 adjustedMoveRange = new Vector3(
            m_moveRange.x * zoomFactor,
            0f,
            m_moveRange.z * zoomFactor
            );

        //移動範囲制限.
        Vector3 currentPos = m_camera.transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, -adjustedMoveRange.x, adjustedMoveRange.x);
        currentPos.z = Mathf.Clamp(currentPos.z, -adjustedMoveRange.z, adjustedMoveRange.z);

        Debug.Log(adjustedMoveRange);
        m_camera.transform.position = currentPos;
    }

    public void Zoom(Vector2 scroll)
    {
        if (scroll.y == 0f)
            return;

        float zoomAmount= scroll.y * m_zoomSpeed * Time.deltaTime * 50f;
        Ray ray = new Ray(m_camera.transform.position, m_camera.transform.forward);
        float allowedZoom = zoomAmount;

        if (Physics.Raycast(ray, out RaycastHit hit, m_maxDistance * 2, m_groundMask))
        {
            //ズーム倍率の制限.
            if (zoomAmount > 0f)
                allowedZoom = Mathf.Min(zoomAmount, hit.distance - m_minDistance);

            if (zoomAmount < 0f)
                allowedZoom = Mathf.Max(zoomAmount, m_minDistance - m_currentDistance);
        }

        m_currentDistance += allowedZoom;
        m_currentDistance = Mathf.Clamp(m_currentDistance, m_minDistance, m_maxDistance);

        m_camera.transform.position += m_camera.transform.forward * allowedZoom;
    }
}
