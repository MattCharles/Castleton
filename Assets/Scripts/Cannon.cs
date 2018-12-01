using UnityEngine;

class Cannon : MonoBehaviour
{
    public Vector3 NozzlePosition;
    public float perscription = 1f;
    public float explosiveness = 40f;
    public float explosiveVariance = 5f;
    public void AIShoots(Block block, Vector3 target)
    {
        Block shot = Instantiate(block, NozzlePosition, Quaternion.identity);
        Vector3 destination = AIAim(target);
        float force = Random.Range(explosiveness - explosiveVariance, explosiveness);
        shot.transform.LookAt(destination);
        shot.GetComponent<Rigidbody>().AddForce(destination * force);
    }

    public void Shoot(Block block, Vector3 forceVector)
    {
        Block shot = Instantiate(block, NozzlePosition, Quaternion.identity);
        shot.transform.LookAt(forceVector);
        shot.GetComponent<Rigidbody>().AddForce(forceVector * explosiveness);
    }

    private Vector3 AIAim(Vector3 target)
    {
        float dx = Random.Range(-perscription, perscription);
        float dy = Random.Range(-perscription, perscription);
        float dz = Random.Range(-perscription, perscription);

        return new Vector3(
            target.x + dx,
            target.y + dy,
            target.z + dz
            );
    }
}
