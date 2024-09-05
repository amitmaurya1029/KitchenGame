
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;


public class PlateIconController : MonoBehaviour
{
    [SerializeField] private GameObject imageTemplete;
    [SerializeField] private PlateKitchenObject plateKitchenObject;
     
    void Start()
    {
        plateKitchenObject.OnIngredientAdd += DisplayIcons;
        
    }

    private void DisplayIcons(object sender, PlateKitchenObject.IngredientEventArgs e)
    {
        foreach (Transform item in this.transform)
        {
            if (imageTemplete == item.gameObject) continue;
            Destroy(item.gameObject);
        }

        foreach (KitchenObjectSO item in e.kitchenObjectSOList)
        {
            GameObject icon = Instantiate(imageTemplete, transform);
            icon.GetComponent<SingleIconUI>().SetIcon(item);
            icon.SetActive(true);
        }
    }

   
    // going to put the images to individual icons data will get from kitchenobjectSO
    
}
