using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ImgCharacter : MonoBehaviour
{

    public static ImgCharacter Instance { get; private set; }

    // Define el diccionario que mapea los nombres de los sprites a valores enteros de 6 dígitos
    public Dictionary<string, Sprite> CharacterValueDictionary { get; private set; }


    public Sprite Aiko;
    public Sprite Akari;
    public Sprite Miyu;
    public Sprite Yuka;
    public Sprite Rina;
    public Sprite Risa;
    public Sprite Yuko;
    public Sprite Ayumi;
    public Sprite Haruka;
    public Sprite Hiroko;
    public Sprite Amaya;
    public Sprite Emi;
    public Sprite Saki;
    public Sprite Kanako;
    public Sprite Keiko;
    public Sprite Meiko;
    public Sprite Mio;
    public Sprite Natsumi;
    public Sprite Hana;
    public Sprite kaori;
    public Sprite Mei;
    public Sprite Sakura;
    public Sprite Kaito;
    public Sprite Kanna;
    public Sprite Yumi;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializeDictionary();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeDictionary()
    {
        CharacterValueDictionary = new Dictionary<string, Sprite>();

        // Agrega los nombres de los sprites y los valores enteros correspondientes al diccionario
        CharacterValueDictionary.Add("Aiko", Aiko);
        CharacterValueDictionary.Add("Akari", Akari);
        CharacterValueDictionary.Add("Miyu", Miyu);
        CharacterValueDictionary.Add("Yuka", Yuka);
        CharacterValueDictionary.Add("Rina", Rina);
        CharacterValueDictionary.Add("Risa", Risa);
        CharacterValueDictionary.Add("Yuko", Yuko);
        CharacterValueDictionary.Add("Ayumi", Ayumi);
        CharacterValueDictionary.Add("Haruka", Haruka);
        CharacterValueDictionary.Add("Hiroko", Hiroko);
        CharacterValueDictionary.Add("Amaya", Amaya);
        CharacterValueDictionary.Add("Emi", Emi);
        CharacterValueDictionary.Add("Saki", Saki);
        CharacterValueDictionary.Add("Kanako", Kanako);
        CharacterValueDictionary.Add("Keiko", Keiko);
        CharacterValueDictionary.Add("Meiko", Meiko);
        CharacterValueDictionary.Add("Mio", Mio);
        CharacterValueDictionary.Add("Natsumi", Natsumi);
        CharacterValueDictionary.Add("Hana", Hana);
        CharacterValueDictionary.Add("Kaori", kaori);
        CharacterValueDictionary.Add("Mei", Mei);
        CharacterValueDictionary.Add("Sakura", Sakura);
        CharacterValueDictionary.Add("Kaito", Kaito);
        CharacterValueDictionary.Add("Kanna", Kanna);
        CharacterValueDictionary.Add("Yumi", Yumi);
    }


    public Sprite GetCharacterSprite(Character character)
    {
        switch (character.Name)
        {
            case "Aiko":
                return Aiko;
            case "Akari":
                return Akari;
            case "Miyu":
                return Miyu;
            case "Yuka":
                return Yuka;
            case "Rina":
                return Rina;
            case "Risa":
                return Risa;
            case "Yuko":
                return Yuko;
            case "Ayumi":
                return Ayumi;
            case "Haruka":
                return Haruka;
            case "Hiroko":
                return Hiroko;
            case "Amaya":
                return Amaya;
            case "Emi":
                return Emi;
            case "Saki":
                return Saki;
            case "Kanako":
                return Kanako;
            case "Keiko":
                return Keiko;
            case "Meiko":
                return Meiko;
            case "Mio":
                return Mio;
            case "Natsumi":
                return Natsumi;
            case "Hana":
                return Hana;
            case "Kaori":
                return kaori;
            case "Mei":
                return Mei;
            case "Sakura":
                return Sakura;
            case "Kaito":
                return Kaito;
            case "Kanna":
                return Kanna;
            case "Yumi":
                return Yumi;
            default:
                return null;
        }
    }

}
