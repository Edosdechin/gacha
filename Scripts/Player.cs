using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player();
            }
            return instance;
        }
    }

    private Dictionary<int, Character> characters; // Diccionario de personajes del jugador, donde la clave es el ID del personaje
    private Dictionary<int, int> fragmentos; // Diccionario de fragmentos por personaje, donde la clave es el ID del personaje
    private Dictionary<int, int> essencias; // Diccionario de esencia por rango, donde la clave es el ID del rango

    private List<Character> listofcharacters;

    public int tiradas; // Número de tiradas disponibles para el jugador
    public int moneda; // Moneda utilizada para las tiradas
    public int Coins; // Número de tiradas disponibles para el jugador
    public int Scrolls; // Moneda utilizada para las tiradas

    public bool HasCharacter(int characterID)
    {
        return characters.ContainsKey(characterID);
    }


    public void AddListCharacters(Character charcter)
    {
        listofcharacters.Add(charcter);
    }
    public void AddFragmentos(int characterID, int fragmentosObtenidos)
    {
        if (fragmentos.ContainsKey(characterID))
        {
            fragmentos[characterID] += fragmentosObtenidos;
        }
        else
        {
            fragmentos.Add(characterID, fragmentosObtenidos);
        }
    }

    public void AddEssencia(int rangoID, int essenciaObtenida)
    {
        if (essencias.ContainsKey(rangoID))
        {
            essencias[rangoID] += essenciaObtenida;
        }
        else
        {
            essencias.Add(rangoID, essenciaObtenida);
        }
    }

    public void AddCharacter(int characterID, Character character)
    {
        if (!characters.ContainsKey(characterID))
        {
            characters.Add(characterID, character);
        }
    }

    // Obtener Characters y Fragmentos en posesion
    public List<Character> GetCharacters()
    {
        return new List<Character>(characters.Values);
    }

    public int GetFragmentos(int characterID)
    {
        if (fragmentos.ContainsKey(characterID))
        {
            return fragmentos[characterID];
        }
        return 0;
    }

    public int GetEssencias(int rangoID)
    {
        if (essencias.ContainsKey(rangoID))
        {
            return essencias[rangoID];
        }
        return 0;
    }

    public List<Character> GetListCharacters()
    {
        return listofcharacters;
    }

    private Player()
    {
        characters = new Dictionary<int, Character>();
        fragmentos = new Dictionary<int, int>();
        essencias = new Dictionary<int, int>();
        listofcharacters = new List<Character>();
        tiradas = 0;
        moneda = 500000;
        Coins = 10000000;
        Scrolls = 500000;
    }
}