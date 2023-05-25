using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ImgRanks : MonoBehaviour
{

    public static ImgRanks Instance { get; private set; }

    // Define el diccionario que mapea los nombres de los sprites a valores enteros de 6 dígitos
    public Dictionary<char, Sprite> ImgRanksValueDictionary { get; private set; }
    public Dictionary<char, Sprite> ImgMarcRanksValueDictionary { get; private set; }

    public Sprite Drank;
    public Sprite Crank;
    public Sprite Brank;
    public Sprite Arank;
    public Sprite Srank;
    public Sprite SSrank;
    public Sprite SSSrank;



    public Sprite DmarcRank;
    public Sprite CmarcRank;
    public Sprite BmarcRank;
    public Sprite AmarcRank;
    public Sprite SmarcRank;
    public Sprite SSmarcRank;
    public Sprite SSSmarcRank;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializeRankDictionary();
            InitializeMarcDictionary();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeRankDictionary()
    {
        ImgRanksValueDictionary = new Dictionary<char, Sprite>();

        // Agrega los nombres de los sprites y los valores enteros correspondientes al diccionario
        ImgRanksValueDictionary.Add('D', Drank);
        ImgRanksValueDictionary.Add('C', Crank);
        ImgRanksValueDictionary.Add('B', Brank);
        ImgRanksValueDictionary.Add('A', Arank);
        ImgRanksValueDictionary.Add('S', Srank);
        ImgRanksValueDictionary.Add('T', SSrank);
        ImgRanksValueDictionary.Add('U', SSSrank);
    }

    private void InitializeMarcDictionary()
    {
        ImgMarcRanksValueDictionary = new Dictionary<char, Sprite>();

        // Agrega los nombres de los sprites y los valores enteros correspondientes al diccionario
        ImgMarcRanksValueDictionary.Add('D', DmarcRank);
        ImgMarcRanksValueDictionary.Add('C', CmarcRank);
        ImgMarcRanksValueDictionary.Add('B', BmarcRank);
        ImgMarcRanksValueDictionary.Add('A', AmarcRank);
        ImgMarcRanksValueDictionary.Add('S', SmarcRank);
        ImgMarcRanksValueDictionary.Add('T', SSmarcRank);
        ImgMarcRanksValueDictionary.Add('U', SSSmarcRank);
    }
}
