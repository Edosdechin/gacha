using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGachaSystem : MonoBehaviour
{
    [SerializeField]
    private UICharacterGacha characterGachaPreFab;
    [SerializeField]
    private RectTransform panelContent;

    public void ShowCharacterUI(Character character)
    {
        // Crear una instancia del prefab de personaje
        UICharacterGacha uiCharacter = Instantiate(characterGachaPreFab, Vector3.zero, Quaternion.identity);
        uiCharacter.transform.SetParent(panelContent); // Establecer el padre del prefab en el panel de contenido o contenedor deseado
        


        // Asignar los datos del personaje a los elementos de UI
        string spriteName = character.Name;

        // Asignar el sprite del personaje
        if (ImgCharacter.Instance.CharacterValueDictionary.ContainsKey(spriteName))
        {
            Sprite sprite = ImgCharacter.Instance.CharacterValueDictionary[spriteName];
            uiCharacter.character.sprite = sprite;// Asignar la imagen del personaje (ajusta esto según la estructura de tu Character)
        }

        // Asignar el sprite del rango
        if (ImgRanks.Instance.ImgRanksValueDictionary.ContainsKey(character.Rank))
        {
            Sprite rankSprite = ImgRanks.Instance.ImgRanksValueDictionary[character.Rank];
            uiCharacter.rank.sprite = rankSprite; // Asignar el sprite del rango (ajusta esto según la estructura de tu Character)
        }

        // Asignar el sprite del marco del rango
        if (ImgRanks.Instance.ImgMarcRanksValueDictionary.ContainsKey(character.Rank))
        {
            Sprite marcSprite = ImgRanks.Instance.ImgMarcRanksValueDictionary[character.Rank];
            uiCharacter.marco.sprite = marcSprite; // Asignar el sprite del marco del personaje (ajusta esto según la estructura de tu Character)
            
        }
        /*
        uiCharacter.bannerRank.sprite = character.BannerRankSprite; // Asignar el sprite del banner del rango (ajusta esto según la estructura de tu Character)
        uiCharacter.badgeClass.sprite = character.ClassBadgeSprite; // Asignar el sprite del emblema de clase (ajusta esto según la estructura de tu Character)
        */
        uiCharacter.characterName.text = character.Name; // Asignar el nombre del personaje

        // Asegurarse de que el objeto se muestre correctamente en la interfaz de usuario
        uiCharacter.gameObject.SetActive(true);
    }




}
