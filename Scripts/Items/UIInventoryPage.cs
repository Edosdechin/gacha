using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPage : MonoBehaviour
{



    [SerializeField]
    private UIInventoryItem itemPreFab;
    [SerializeField]
    private UICharacterLocked characterLockedPreFab;
    [SerializeField]
    private RectTransform contentPanel;

    List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();
    List<UICharacterLocked> listOfUICharacters = new List<UICharacterLocked>();

    public void InitializeInventoryUI(int inventorysize)
    {
        
        for(int i =0; i < inventorysize; i++)
        {
            UIInventoryItem uiItem =
                Instantiate(itemPreFab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            listOfUIItems.Add(uiItem);
        }
    }
    public void InitializeCharactersUI(int inventorySize)
    {
        List<Character> listOfCharacters = Player.Instance.GetListCharacters();

        // Filtrar personajes adquiridos y bloqueados
        List<Character> acquiredCharacters = listOfCharacters.FindAll(character => Player.Instance.HasCharacter(character.ID));
        List<Character> lockedCharacters = listOfCharacters.FindAll(character => !Player.Instance.HasCharacter(character.ID));

        // Establecer el orden personalizado
        Dictionary<char, int> characterOrder = new Dictionary<char, int>()
    {
        {'U', 0},
        {'T', 1},
        {'S', 2},
        {'A', 3},
        {'B', 4},
        {'C', 5},
        {'D', 6}
    };

        // Ordenar personajes adquiridos de acuerdo al orden personalizado
        acquiredCharacters.Sort((a, b) => characterOrder[a.Rank].CompareTo(characterOrder[b.Rank]));

        // Ordenar personajes bloqueados por rango (de mayor a menor)
        lockedCharacters.Sort((a, b) => b.Rank.CompareTo(a.Rank));

        // Asegurarse de que el tamaño del inventario no supere la cantidad de personajes disponibles
        inventorySize = Mathf.Min(inventorySize, acquiredCharacters.Count + lockedCharacters.Count);

        // Verificar si el número de elementos UI existentes coincide con el tamaño del inventario
        if (listOfUICharacters.Count != inventorySize)
        {
            // Eliminar elementos UI adicionales si hay más de los necesarios
            if (listOfUICharacters.Count > inventorySize)
            {
                for (int i = inventorySize; i < listOfUICharacters.Count; i++)
                {
                    Destroy(listOfUICharacters[i].gameObject);
                }
                listOfUICharacters.RemoveRange(inventorySize, listOfUICharacters.Count - inventorySize);
            }
            else // Agregar elementos UI adicionales si hay menos de los necesarios
            {
                for (int i = listOfUICharacters.Count; i < inventorySize; i++)
                {
                    UICharacterLocked uiItem = Instantiate(characterLockedPreFab, Vector3.zero, Quaternion.identity);
                    uiItem.transform.SetParent(contentPanel);
                    listOfUICharacters.Add(uiItem);
                }
            }
        }

        int acquiredIndex = 0;
        int lockedIndex = 0;

        for (int i = 0; i < inventorySize; i++)
        {
            UICharacterLocked uiItem = listOfUICharacters[i];

            Character character;

            // Determinar el personaje a mostrar en esta posición
            if (i < acquiredCharacters.Count)
            {
                character = acquiredCharacters[acquiredIndex];
                acquiredIndex++;
            }
            else
            {
                character = lockedCharacters[lockedIndex];
                lockedIndex++;
            }

            string spriteName = character.Name;

            // Asignar el sprite del personaje
            if (ImgCharacter.Instance.CharacterValueDictionary.ContainsKey(spriteName))
            {
                Sprite sprite = ImgCharacter.Instance.CharacterValueDictionary[spriteName];
                uiItem.character.sprite = sprite;
            }

            // Asignar el sprite del rango
            if (ImgRanks.Instance.ImgRanksValueDictionary.ContainsKey(character.Rank))
            {
                Sprite rankSprite = ImgRanks.Instance.ImgRanksValueDictionary[character.Rank];
                uiItem.rank.sprite = rankSprite;
            }

            // Asignar el sprite del marco del rango
            if (ImgRanks.Instance.ImgMarcRanksValueDictionary.ContainsKey(character.Rank))
            {
                Sprite marcSprite = ImgRanks.Instance.ImgMarcRanksValueDictionary[character.Rank];
                uiItem.marco.sprite = marcSprite;
            }

            // Verificar si el personaje está desbloqueado por el jugador
            if (Player.Instance.HasCharacter(character.ID))
            {
                uiItem.padLock.gameObject.SetActive(false);
                uiItem.blur.gameObject.SetActive(false);
            }
            else
            {
                uiItem.padLock.gameObject.SetActive(true);
                uiItem.blur.gameObject.SetActive(true);
            }
        }
    }


}
