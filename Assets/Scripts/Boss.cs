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
            Invoke("OpenTrapTwo", 3f);
            Invoke("OpenTrapOne", 3f);
        }
    }
    void OpenTrapTwo()
    {
        twoTrap.SetActive(true);
        oneTrap.SetActive(false);
    }
    void OpenTrapOne()
    {
        twoTrap.SetActive(false);
        oneTrap.SetActive(true);
    }
}
