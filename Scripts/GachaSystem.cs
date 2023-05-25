using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GachaSystem
{
    public List<Character> characters; // Lista de personajes disponibles
    public int costPerPull = 10; // Costo por tirada
    public int maxPulls = 100; // Máximo número de tiros para obtener el personaje deseado

    public Character GetRandomCharacter1(List<Character> characters)
    {
        // Obtén un personaje aleatorio basado en las probabilidades
        float randomValue = Random.value;
        float cumulativeProbability = 0f;
        Debug.Log("Número aleatorio: " + randomValue);
        foreach (Character character in characters)
        {
            cumulativeProbability += GetRankWeight(character.Rank);

            if (randomValue <= cumulativeProbability)
            {
                return character;
            }
        }

        return null; // Si no se encuentra ningún personaje, devuelve null
    }

    /*
     * En esta versión, se crea una lista cumulativeProbabilities que almacena tuplas de personajes junto con sus probabilidades acumuladas. 
     * Primero, se calcula el peso total sumando los pesos de los personajes. Luego, se genera un valor aleatorio dentro del rango total de pesos. 
     * Por último, se busca en la lista de probabilidades acumuladas el personaje correspondiente al valor aleatorio y se devuelve.
     */
    public Character GetRandomCharacter(List<Character> characters)
    {
        // Crea una lista auxiliar para almacenar los personajes con sus probabilidades acumuladas
        List<(Character, float)> cumulativeProbabilities = new List<(Character, float)>();

        // Calcula las probabilidades acumuladas para cada personaje
        float totalWeight = 0f;
        foreach (Character character in characters)
        {
            float rankWeight = GetRankWeight(character.Rank);
            totalWeight += rankWeight;
            cumulativeProbabilities.Add((character, totalWeight));
        }

        // Obtén un valor aleatorio entre 0 y el total de pesos
        float randomValue = Random.Range(0f, totalWeight);
        Debug.Log("Número aleatorio: " + randomValue);

        // Busca el personaje correspondiente al valor aleatorio en la lista de probabilidades acumuladas
        foreach ((Character character, float cumulativeProbability) in cumulativeProbabilities)
        {
            if (randomValue <= cumulativeProbability)
            {
                return character;
            }
        }

        return null; // Si no se encuentra ningún personaje, devuelve null
    }

    public bool CanPull()
    {
        // Verifica si se puede realizar una tirada en función del costo y el número máximo de tiros
        // Si el jugador tiene suficiente cantidad de tiradas restantes y no ha alcanzado el límite máximo de tiros, devuelve true
        // De lo contrario, devuelve false
        return (Player.Instance.moneda >= costPerPull && Player.Instance.tiradas <= maxPulls);
    }

    public bool CanPerformPulls(int numPulls)
    {
        // Verifica si se pueden realizar las tiradas en función del costo y el número máximo de tiros
        // Si el jugador tiene suficiente cantidad de tiradas restantes y no ha alcanzado el límite máximo de tiros, devuelve true
        // De lo contrario, devuelve false
        return (Player.Instance.moneda >= (costPerPull * numPulls) && Player.Instance.tiradas + numPulls <= maxPulls);
    }

    public Character PerformPull(List<Character> characters)
    {
        if (CanPull())
        {
            Player.Instance.moneda -= costPerPull; // Resta el costo de la tirada al contador de monedas del jugador
            Player.Instance.tiradas += 1; // Incrementa el contador de tiradas del jugador

            Character pulledCharacter = GetRandomCharacter(characters); // Obtiene un personaje aleatorio

            // Realiza las acciones correspondientes con el personaje obtenido, como agregarlo al inventario del jugador, mostrarlo en pantalla, etc.
            if (pulledCharacter != null)
            {
                Debug.Log("Personaje Rank "+ pulledCharacter.Rank+": " + pulledCharacter.Name);
                // Realiza las acciones necesarias con el personaje obtenido

                if (pulledCharacter.Rank == 'U')
                {
                    Player.Instance.tiradas = 0; // Reinicia el contador de tiradas a 0
                    Debug.Log("¡Obtuviste un personaje de rango U! El contador de tiradas se ha reiniciado.");
                }
                else if (Player.Instance.tiradas >= 100)
                {
                    pulledCharacter = GetRandomURCharacter(characters); // Obtiene un personaje de rango U garantizado
                    Player.Instance.tiradas = 0; // Reinicia el contador de tiradas a 0
                    Debug.Log("Se han realizado 100 tiros sin obtener un personaje de rango U. En esta tirada obtuviste: " + pulledCharacter.Name);
                }
                else if (Player.Instance.HasCharacter(pulledCharacter.ID)) // Verifica si el jugador ya tiene el personaje por su ID
                {
                    int fragmentosObtenidos = GetFragmentosPorRango(pulledCharacter.Rank); // Obtiene la cantidad de fragmentos según el rango del personaje
                    Player.Instance.AddFragmentos(pulledCharacter.ID, fragmentosObtenidos); // Agrega los fragmentos adicionales al personaje existente
                    int rangoID = GetRangoID(pulledCharacter.Rank); // Obtén el ID del rango del personaje
                    int esenciaObtenida = GetEsenciaPorRangoID(rangoID); // Obtiene la cantidad de esencia según el ID del rango del personaje
                    Player.Instance.AddEssencia(rangoID, esenciaObtenida);
                    Debug.Log("Has obtenido " + fragmentosObtenidos + " fragmentos de " + pulledCharacter.Name + " y " + esenciaObtenida + " esencia de rango");
                }
                else
                {
                    Player.Instance.AddCharacter(pulledCharacter.ID, pulledCharacter); // Agrega el personaje al jugador
                    int rangoID = GetRangoID(pulledCharacter.Rank); // Obtén el ID del rango del personaje
                    int esenciaObtenida = GetEsenciaPorRangoID(rangoID); // Obtiene la cantidad de esencia según el ID del rango del personaje
                    Player.Instance.AddEssencia(rangoID, esenciaObtenida);
                    Debug.Log("Has obtenido un nuevo personaje: " + pulledCharacter.Name + " y " + esenciaObtenida + " esencia de rango");

                }
            }
            else
            {
                Debug.Log("No se ha obtenido ningún personaje.");
            }
        }
        else
        {
            Debug.Log("No puedes realizar una tirada.");
        }

        return null; // Si no se encuentra ningún personaje, devuelve null
    }


    public List<Character> PerformPulls(List<Character> characters, int numPulls)
    {
        List<Character> pulledCharacters = new List<Character>();

        if (CanPerformPulls(numPulls))
        {
            for (int i = 0; i < numPulls; i++)
            {
                Character randomCharacter = PerformPull(characters);
                pulledCharacters.Add(randomCharacter);
            }

            Player.Instance.moneda -= costPerPull * numPulls;
            
        }

        return pulledCharacters;
    }


    private Character GetRandomURCharacter(List<Character> characters)
    {
        List<Character> URCharacters = characters.Where(c => c.Rank == 'U').ToList();
        if (URCharacters.Count > 0)
        {
            int randomIndex = Random.Range(0, URCharacters.Count);
            return URCharacters[randomIndex];
        }
        return null;
    }

    
    private float GetRankWeight(char rank)
    {
        switch (rank)
        {
            case 'D':
                return 0.50f;
            case 'C':
                return 0.22f;
            case 'B':
                return 0.15f;
            case 'A':
                return 0.08f;
            case 'S':
                return 0.03f;
            case 'T':
                return 0.015f;
            case 'U':
                return 0.005f;
            default:
                return 0f;
        }
    }

    private int GetFragmentosPorRango(char rango)
    {
        // Define la cantidad de fragmentos por rango
        switch (rango)
        {
            case 'D':
                return 1;
            case 'C':
                return 2;
            case 'B':
                return 3;
            case 'A':
                return 4;
            case 'S':
                return 5;
            case 'T':
                return 6;
            case 'U':
                return 7;
            default:
                return 0;
        }
    }

    public int GetRangoID(char rango)
    {
        // Aquí puedes definir una lógica para asignar un ID único a cada rango
        // Por ejemplo, puedes usar un diccionario que mapee cada rango a su correspondiente ID
        Dictionary<char, int> rangoIDs = new Dictionary<char, int>()
    {
        {'D', 1},
        {'C', 2},
        {'B', 3},
        {'A', 4},
        {'S', 5},
        {'T', 6},
        {'U', 7}
    };

        // Verifica si el rango existe en el diccionario y devuelve el ID correspondiente
        if (rangoIDs.ContainsKey(rango))
        {
            return rangoIDs[rango];
        }

        // Si el rango no se encuentra en el diccionario, puedes devolver un ID predeterminado o lanzar una excepción, dependiendo de tu lógica de negocio
        // En este ejemplo, se devuelve un ID de 0 si el rango no está definido
        return 0;
    }

    private int GetEsenciaPorRangoID(int rangoID)
    {
        // Aquí puedes definir una lógica para obtener la cantidad de esencia basada en el ID del rango
        // Puedes utilizar un diccionario que mapee cada ID de rango a la cantidad de esencia correspondiente
        Dictionary<int, int> esenciaPorRangoID = new Dictionary<int, int>()
    {
        {1, 10}, // ID 1 corresponde a rango 'UC'
        {2, 20}, // ID 2 corresponde a rango 'C'
        {3, 30}, // ID 3 corresponde a rango 'R'
        {4, 40}, // ID 4 corresponde a rango 'UR'
        {5, 50},  // ID 5 corresponde a rango 'SR'
        {6, 100},  // ID 5 corresponde a rango 'SSR'
        {7, 200}  // ID 5 corresponde a rango 'ESP'
    };

        // Verifica si el rango ID existe en el diccionario y devuelve la cantidad de esencia correspondiente
        if (esenciaPorRangoID.ContainsKey(rangoID))
        {
            return esenciaPorRangoID[rangoID];
        }

        // Si el rango ID no se encuentra en el diccionario, puedes devolver una cantidad de esencia predeterminada o lanzar una excepción, dependiendo de tu lógica de negocio
        // En este ejemplo, se devuelve una cantidad de esencia de 0 si el rango ID no está definido
        return 0;
    }

    public char GetRangoChar(int rankID)
    {
        switch (rankID)
        {
            case 1:
                return 'D';
            case 2:
                return 'C';
            case 3:
                return 'B';
            case 4:
                return 'A';
            case 5:
                return 'S';
            case 6:
                return 'T';
            case 7:
                return 'U';
            default:
                return '?'; // Carácter por defecto en caso de rango desconocido
        }
    }

    
}
