using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    [SerializeField] private SnipCreator _snipCreator;

    public void Cut(Block previousBlock, Block currentBlock)
    {
        Vector3 snipScale = new Vector3(currentBlock.transform.position.x - previousBlock.transform.position.x, 0, currentBlock.transform.position.z - previousBlock.transform.position.z);

        if (Mathf.Abs(snipScale.x) >= currentBlock.transform.localScale.x || Mathf.Abs(snipScale.z) >= currentBlock.transform.localScale.z)
        {
            Time.timeScale = 0;
            return;
        }

        if(Mathf.Abs(snipScale.x) <= 0.1f && snipScale.x > 0 || Mathf.Abs(snipScale.z) <= 0.1f && snipScale.z > 0) 
        {
            currentBlock.transform.position = new Vector3(previousBlock.transform.position.x, currentBlock.transform.position.y, previousBlock.transform.position.z);
            currentBlock.ParticleController.ParticalPlay();
        }
        else
        {
            currentBlock.Resize(currentBlock.transform.localScale.x - Mathf.Abs(snipScale.x), currentBlock.transform.localScale.z - Mathf.Abs(snipScale.z));
            currentBlock.Relocate(snipScale.x, snipScale.z);
            _snipCreator.Create(snipScale, currentBlock);
        }
    }
}
