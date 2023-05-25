using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public static GachaSystem GachaSystemInstance { get; private set; }
    GachaSystem gachaSystem = new GachaSystem();
    private void Awake()
    {
        GachaSystemInstance = new GachaSystem();
    }

    private List<Character> characters;
    private Team playerTeam;
    private Team IATeam;
    public Character selectedCharacter;


    [SerializeField]
    private UIInventoryPage iventoryUI;
    [SerializeField]
    private UICharacterGacha characterGachaPreFab;
    public GameObject uigacha;


    public Text moneda;
    public Text tiradas;


    public Controller()
    {
        characters = new List<Character>();
    }

    public void Start()
    {
        // Aquí puedes realizar la inicialización de tu proyecto, como cargar los personajes, configurar equipos, etc.
        LoadCharacters();
        SetupTeams();
        DataLoad();
    }

   


    private void LoadCharacters()
    {
        // Código para cargar los personajes desde un origen de datos (archivo, base de datos, etc.)
        // Agrega los personajes a la lista characters
        // Ejemplo:
        // Continúa agregando más personajes según sea necesario

        characters.Add(new Character("Aiko", "Descripción D","SUP", 'D', 000001));
        characters.Add(new Character("Akari", "Descripción D", "SUP", 'D', 000002));
        characters.Add(new Character("Miyu", "Descripción D", "SUP", 'D', 000003));
        characters.Add(new Character("Yuka", "Descripción D", "SUP", 'D', 000004));
        characters.Add(new Character("Rina", "Descripción C", "SUP", 'C', 000005));
        characters.Add(new Character("Risa", "Descripción C", "SUP", 'C', 000006));
        characters.Add(new Character("Yuko", "Descripción C", "SUP", 'C', 000007));
        characters.Add(new Character("Ayumi", "Descripción B", "SUP", 'B', 000008));
        characters.Add(new Character("Haruka", "Descripción B", "SUP", 'B', 000009));
        characters.Add(new Character("Hiroko", "Descripción B", "SUP", 'B', 000010));
        characters.Add(new Character("Amaya", "Descripción A", "SUP", 'A', 000011));
        characters.Add(new Character("Emi", "Descripción A", "SUP", 'A', 000012));
        characters.Add(new Character("Saki", "Descripción A", "SUP", 'A', 000013));
        characters.Add(new Character("Kanako", "Descripción S", "SUP", 'S', 000014));
        characters.Add(new Character("Keiko", "Descripción S", "SUP", 'S', 000015));
        characters.Add(new Character("Meiko", "Descripción S", "SUP", 'S', 000016));
        characters.Add(new Character("Mio", "Descripción S", "SUP", 'S', 000017));
        characters.Add(new Character("Natsumi", "Descripción S", "SUP", 'S', 000018));
        characters.Add(new Character("Hana", "Descripción SS", "SUP", 'T', 000019));
        characters.Add(new Character("Kaori", "Descripción SS", "SUP", 'T', 000020));
        characters.Add(new Character("Mei", "Descripción SS", "SUP", 'T', 000021));
        characters.Add(new Character("Sakura", "Descripción SS", "SUP", 'T', 000022));
        characters.Add(new Character("Kaito", "Descripción SSS", "SUP", 'U', 000023));
        characters.Add(new Character("Kanna", "Descripción SSS", "SUP", 'U', 000024));
        characters.Add(new Character("Yumi", "Descripción SSS", "SUP", 'U', 000025));

        foreach (Character character in characters)
        {
            Player.Instance.AddListCharacters(character);
            Debug.Log("Character " + character.Name);
        }
        
    }


    private void LoadMapsInstance()
    {
        // Crear el objeto de mapa global
        GlobalMap globalMap = new GlobalMap();

        // Crear los mapas
        Map map1 = new Map("Mapa 1");
        Map map2 = new Map("Mapa 2");

        // Crear las instancias y recompensas del mapa 1
        Instance instance1_1 = new Instance("Instancia 1-1");
        instance1_1.FirstClearReward = new Reward("Recompensa 1-1 Primer Clear");
        instance1_1.ExtraStarReward = new Reward("Recompensa 1-1 Estrella Extra");
        Instance instance1_2 = new Instance("Instancia 1-2");
        instance1_2.FirstClearReward = new Reward("Recompensa 1-2 Primer Clear");
        instance1_2.ExtraStarReward = new Reward("Recompensa 1-2 Estrella Extra");

        // Añadir instancias al mapa 1
        map1.Instances.Add(instance1_1);
        map1.Instances.Add(instance1_2);


        // Crear las instancias y recompensas del mapa 2
        Instance instance2_1 = new Instance("Instancia 2-1");
        instance2_1.FirstClearReward = new Reward("Recompensa 2-1 Primer Clear");
        instance2_1.ExtraStarReward = new Reward("Recompensa 2-1 Estrella Extra");
        Instance instance2_2 = new Instance("Instancia 2-2");
        instance2_2.FirstClearReward = new Reward("Recompensa 2-2 Primer Clear");
        instance2_2.ExtraStarReward = new Reward("Recompensa 2-2 Estrella Extra");

        // Añadir instancias al mapa 2
        map2.Instances.Add(instance2_1);
        map2.Instances.Add(instance2_2);

        // Añadir los mapas al mapa global
        globalMap.AddMap(map1);
        globalMap.AddMap(map2);

        if (map1.Instances.Count > 0)
        {
            Instance previousInstance = map1.Instances[map1.Instances.Count - 1];
            if (previousInstance.IsUnlocked && previousInstance.Stars >= 1)
            {
                Instance newInstance = new Instance("Instancia 1-3");
                newInstance.FirstClearReward = new Reward("Recompensa 1-3 Primer Clear");
                newInstance.ExtraStarReward = new Reward("Recompensa 1-3 Estrella Extra");
                newInstance.IsUnlocked = true; // Desbloquear la nueva instancia
                map1.Instances.Add(newInstance);
            }
        }

        foreach (Map map in globalMap.Maps)
        {
            Debug.Log("Mapa: " + map.Name);

            // Acceder a las instancias del mapa
            foreach (Instance instance in map.Instances)
            {
                Debug.Log("Instancia: " + instance.Name);
                Debug.Log("Estrellas obtenidas: " + instance.Stars);
                Debug.Log("Completada: " + instance.IsCompleted);

                if (instance.IsCompleted)
                {
                    Debug.Log("Recompensa por primer clear: " + instance.FirstClearReward.Name);
                    Debug.Log("Recompensa por estrella extra: " + instance.ExtraStarReward.Name);
                }
            }
        }
    }
    private void SetupTeams()
    {
        // Código para configurar los equipos (jugador e IA)
        // Puedes utilizar la lista de characters para seleccionar los personajes y asignarlos a los equipos
        // Ejemplo:
        /*
        List<Character> availableCharacters = GetAvailableCharacters('C', 0.2f);
        playerTeam.AddCharacter(availableCharacters[0]);
        playerTeam.AddCharacter(availableCharacters[1]);

        IATeam.AddCharacter(availableCharacters[2]);
        IATeam.AddCharacter(availableCharacters[3]);
        */
    }
    /*
    private List<Character> GetAvailableCharacters(char minRank, float minProbability)
    {
        List<Character> availableCharacters = new List<Character>();

        foreach (Character character in characters)
        {
            if (character.Rank >= minRank && character.Probability >= minProbability)
            {
                availableCharacters.Add(character);
            }
        }

        return availableCharacters;
    }
    */



    //***************************************************************** GachaSystem *****************************************************************
    public void PerfomGacha()
    {
        
        Character randomCharacter = gachaSystem.PerformPull(characters);
        ShowObtainedCharacter(randomCharacter);
        
        DataLoad();
    }

    public void PerfomGachaX10()
    {

        List<Character> listcharacters = gachaSystem.PerformPulls(characters, 10);

        DataLoad();

    }

    public void ShowObtainedCharacter1(Character character)
    {
        // Asignar los datos del personaje a los elementos de UI
        string spriteName = character.Name;

        // Asignar el sprite del personaje
        if (ImgCharacter.Instance.CharacterValueDictionary.ContainsKey(spriteName))
        {
            Sprite sprite = ImgCharacter.Instance.CharacterValueDictionary[spriteName];
            characterGachaPreFab.character.sprite = sprite;// Asignar la imagen del personaje (ajusta esto según la estructura de tu Character)
        }

        // Asignar el sprite del rango
        if (ImgRanks.Instance.ImgRanksValueDictionary.ContainsKey(character.Rank))
        {
            Sprite rankSprite = ImgRanks.Instance.ImgRanksValueDictionary[character.Rank];
            characterGachaPreFab.rank.sprite = rankSprite; // Asignar el sprite del rango (ajusta esto según la estructura de tu Character)
        }

        // Asignar el sprite del marco del rango
        if (ImgRanks.Instance.ImgMarcRanksValueDictionary.ContainsKey(character.Rank))
        {
            Sprite marcSprite = ImgRanks.Instance.ImgMarcRanksValueDictionary[character.Rank];
            characterGachaPreFab.marco.sprite = marcSprite; // Asignar el sprite del marco del personaje (ajusta esto según la estructura de tu Character)

        }
        /*
        uiCharacter.bannerRank.sprite = character.BannerRankSprite; // Asignar el sprite del banner del rango (ajusta esto según la estructura de tu Character)
        uiCharacter.badgeClass.sprite = character.ClassBadgeSprite; // Asignar el sprite del emblema de clase (ajusta esto según la estructura de tu Character)
        */
        characterGachaPreFab.characterName.text = character.Name; // Asignar el nombre del personaje
        

    }
    public void ShowObtainedCharacter(Character character)
    {
        Sprite sprite = ImgCharacter.Instance.CharacterValueDictionary[character.Name];
        characterGachaPreFab.character.sprite = ImgCharacter.Instance.GetCharacterSprite(character);// Asignar la imagen del personaje (ajusta esto según la estructura de tu Character)   

    }

    public void StartBattle()
    {
        
        
    }
    


    public void ShowPlayerInventory()
    {
        
    }

    public void ShowPlayerCharacters()
    {
    }
    public void SelectCharacter(Character character)
    {
        selectedCharacter = character;
        Team team = new Team();
        if (selectedCharacter != null)
        {
            team.AddCharacter(selectedCharacter);
        }else{
            Debug.Log("Error El character no puede estar vacio");
        }
    }





    private void DataLoad()
    {
        moneda.text = ""+Player.Instance.moneda;
        tiradas.text = "" + Player.Instance.tiradas;
        iventoryUI.InitializeCharactersUI(25);//muestra el inventario de characters disponibles
    }
    // Otros métodos y lógica del controlador según las necesidades de tu proyecto
}
