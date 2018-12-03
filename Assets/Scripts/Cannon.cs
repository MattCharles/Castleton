using Assets.Scripts.Common;
using System.Collections;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Vector3 NozzlePosition;
    public float perscription = 1f;
    public float explosiveness = 40f;
    public float explosiveVariance = 5f;

    public void AIShoots(Block block, Vector3 target)
    {
        block.state = Block.BlockState.Shot;
        block.transform.position = NozzlePosition;
        Vector3 destination = AIAim(target + new Vector3(0f, 4f));
        float force = Random.Range(explosiveness - explosiveVariance, explosiveness);
        block.transform.LookAt(destination);
        block.gameObject.SetActive(true);
        block.blockObj.GetComponent<Rigidbody>().AddForce(destination * force);

        GameObject.FindWithTag(Constants.Tags.soundManager).GetComponent<SoundManager>().PlaySound((int)Constants.Sounds.fire);
    }

    public void Shoot(Block block, Vector3 forceVector)
    {
        /*
        block.state = Block.BlockState.Shot;
        Block shot = Instantiate(block, NozzlePosition, Quaternion.identity);
        shot.transform.LookAt(forceVector);
        shot.GetComponent<Rigidbody>().AddForce(forceVector * explosiveness);

        GameObject.FindWithTag(Constants.Tags.soundManager).GetComponent<SoundManager>().PlaySound((int)Constants.Sounds.fire);
        */
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
