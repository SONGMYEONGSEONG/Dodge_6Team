using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionObj : MonoBehaviour
{
    [SerializeField] List<GameObject> itemObj = new List<GameObject>();
    private void ItemInstantiate()
    {
        Destroy(gameObject);
        System.Random random = new System.Random();
        int itemInsRandom = random.Next(1, 101);

        // 20% 확률로 아이템 생성
        if (itemInsRandom <= 100)
        {
            int itemListRandom = random.Next(0, itemObj.Count);
            Instantiate(itemObj[itemListRandom], gameObject.transform.position, Quaternion.identity);
        }

    }
}
