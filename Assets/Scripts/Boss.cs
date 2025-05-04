using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] GameObject oneTrap;
    [SerializeField] GameObject twoTrap;
    private void Start()
    {
        twoTrap.SetActive(false);
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if(gameObject.activeSelf)
        {
            twoTrap.SetActive(true);
        }
    }
}
