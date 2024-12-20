using UnityEngine;

public class LootHeal : MonoBehaviour, IPickup
{
    //Не выставляй значение, если в инспекторе уже сериализуется поле. Нет смысла, только запутывает
    [SerializeField] private int healthValue = 1;

    //переменную назови не pickup, а pickuper. Вводит в заблуждение
    //Так же лучше использовать TryGetComponent
    public void Pick(Pickuper pickup)
    {
        PlayerHealth playerHealth = pickup.transform.GetComponent<PlayerHealth>();

        if (playerHealth)
        {
            playerHealth.AddHealth(healthValue);
            Destroy(gameObject);
        }
    }
}
