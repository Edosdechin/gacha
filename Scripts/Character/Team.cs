using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{


    public string Name { get; }
    public List<Character> Characters { get; }
    private List<Character> ownedCharacters;

    public Team()
    {

    }
    public Team(string name, List<Character> ownedCharacters)
    {
        Name = name;
        Characters = new List<Character>();
        this.ownedCharacters = ownedCharacters;
    }

    public void AddCharacter(Character character)
    {
        if (ownedCharacters.Contains(character))
        {
            if (Characters.Count < 5)
            {
                Characters.Add(character);
                Debug.Log("Personaje " + character.Name + " agregado al equipo " + Name);
            }
            else
            {
                Debug.Log("El equipo " + Name + " ya tiene el máximo de personajes permitidos.");
            }
        }
        else
        {
            Debug.Log("No puedes agregar el personaje " + character.Name + " al equipo " + Name + " porque no lo has adquirido.");
        }
    }

    public void RemoveCharacter(Character character)
    {
        Characters.Remove(character);
        Debug.Log("Personaje " + character.Name + " removido del equipo " + Name);
    }

    public void ClearTeam()
    {
        Characters.Clear();
        Debug.Log("Equipo " + Name + " vaciado");
    }
}


/*
 * 
 * En esta clase Team, se utiliza una propiedad Name para representar el nombre del equipo y una lista Characters para almacenar los personajes que pertenecen al equipo.

El constructor Team se encarga de establecer el nombre del equipo y crear una nueva instancia de la lista Characters.

La función AddCharacter() permite agregar un personaje al equipo llamando al método Add() de la lista Characters.

La función RemoveCharacter() permite eliminar un personaje del equipo llamando al método Remove() de la lista Characters.

La función ClearTeam() permite vaciar completamente el equipo llamando al método Clear() de la lista Characters.

Puedes personalizar y agregar más funcionalidades a esta clase según las necesidades de tu juego. Por ejemplo, podrías agregar métodos para obtener la cantidad de 
personajes en el equipo, acceder a un personaje específico por su índice, etc.
 * 
 * */