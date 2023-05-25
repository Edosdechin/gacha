public abstract class Equipament
{
    public int ID { get; }
    public string Name { get; }
    public int Level { get; protected set; }
    public int MaxLevel { get; protected set; }
    public int Rank { get; protected set; }
    public int Power { get; protected set; }
    public int Defense { get; protected set; }
    public int Attack { get; protected set; }
    public int Health { get; protected set; }
    public int Speed { get; protected set; }

    public Equipament(int id, string name, int maxLevel, int rank)
    {
        ID = id;
        Name = name;
        Level = 1;
        MaxLevel = maxLevel;
        Rank = rank;
        Power = 0;
        Defense = 0;
        Attack = 0;
        Health = 0;
        Speed = 0;
    }

    public abstract void UpgradeLevel();

    public abstract void UpgradeRank();

    public override string ToString()
    {
        return Name + " (Level " + Level + ")";
    }
}

public class Shoes : Equipament
{
    public float SpeedBoost { get; protected set; }
    public float EvasionBonus { get; protected set; }

    public Shoes(int id, string name, int maxLevel, int rank) : base(id, name, maxLevel, rank)
    {
        // Configura los valores iniciales espec�ficos de los zapatos
        Power = 10;
        Defense = 5;
        Attack = 0;
        Health = 0;
        Speed = 0;
        SpeedBoost = 0.1f; // Aumento de velocidad del 10%
        EvasionBonus = 0.04f; // Bonificaci�n de esquiva del 5%
    }

    public override void UpgradeLevel()
    {
        if (Level < MaxLevel)
        {
            Level++;
            Power += GetPowerIncreaseOnLevelUp();
            Defense += GetDefenseIncreaseOnLevelUp();
            Attack += GetAttackIncreaseOnLevelUp();
            Health += GetHealthIncreaseOnLevelUp();
            Speed += GetSpeedIncreaseOnLevelUp();
            // Incrementa el efecto de velocidad al subir de nivel
            SpeedBoost += 0.02f; // Incremento adicional del 2% en la velocidad de los zapatos

        }
        else
        {
            // El nivel ya est� en su m�ximo
            // Manejar el error o mostrar un mensaje al jugador
        }
    }

    public override void UpgradeRank()
    {
        if (Rank < GetMaxRank())
        {
            Rank++;
            Power += GetPowerIncreaseOnRankUp();
            Defense += GetDefenseIncreaseOnRankUp();
            Attack += GetAttackIncreaseOnRankUp();
            Health += GetHealthIncreaseOnRankUp();
            Speed += GetSpeedIncreaseOnRankUp();
            // Incrementa el efecto de bonificaci�n de esquiva al subir de rango
            EvasionBonus += 0.03f; // Incremento adicional del 3% en la bonificaci�n de esquiva de los zapatos

        }
        else
        {
            // El rango ya est� en su m�ximo
            // Manejar el error o mostrar un mensaje al jugador
        }
    }

    private int GetPowerIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de poder al subir de nivel
        return Level * Rank * 2;
    }

    private int GetDefenseIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de defensa al subir de nivel
        return Level * Rank * 2;
    }

    private int GetAttackIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de ataque al subir de nivel
        return Level * Rank * 2;
    }

    private int GetHealthIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de vida al subir de nivel
        return Level * Rank * 2;
    }

    private int GetSpeedIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de velocidad al subir de nivel
        return Level * Rank * 2;
    }

    private int GetPowerIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de poder al subir de rango
        return Rank * 10;
    }

    private int GetDefenseIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de defensa al subir de rango
        return Rank * 5;
    }

    private int GetAttackIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de ataque al subir de rango
        return Rank * 5;
    }

    private int GetHealthIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de vida al subir de rango
        return Rank * 5;
    }

    private int GetSpeedIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de velocidad al subir de rango
        return Rank * 5;
    }

    private int GetMaxRank()
    {
        // L�gica para determinar el rango m�ximo
        switch (Name)
        {
            case "Shoes":
                return 7; // U
            default:
                return 0;
        }
    }
}


public class Pants : Equipament
{
    public float DefensePercentIncrease { get; protected set; }
    public float ResistanceBonus { get; protected set; }

    public Pants(int id, string name, int maxLevel, int rank) : base(id, name, maxLevel, rank)
    {
        // Configura los valores iniciales espec�ficos de los pantalones
        Power = 10;
        Defense = 5;
        Attack = 0;
        Health = 0;
        Speed = 0;
        DefensePercentIncrease = 0.1f; // Aumento de defensa del 10% 
        ResistanceBonus = 0.1f; // Bonificaci�n de resistencia del 10%
    }

    public override void UpgradeLevel()
    {
        if (Level < MaxLevel)
        {
            Level++;
            Power += GetPowerIncreaseOnLevelUp();
            Defense += GetDefenseIncreaseOnLevelUp();
            Attack += GetAttackIncreaseOnLevelUp();
            Health += GetHealthIncreaseOnLevelUp();
            Speed += GetSpeedIncreaseOnLevelUp();
            // Incrementa el efecto de aumento de defensa porcentual al subir de nivel
            DefensePercentIncrease += 0.05f; // Incremento adicional del 5% en la defensa de los pantalones

        }
        else
        {
            // El nivel ya est� en su m�ximo
            // Manejar el error o mostrar un mensaje al jugador
        }
    }

    public override void UpgradeRank()
    {
        if (Rank < GetMaxRank())
        {
            Rank++;
            Power += GetPowerIncreaseOnRankUp();
            Defense += GetDefenseIncreaseOnRankUp();
            Attack += GetAttackIncreaseOnRankUp();
            Health += GetHealthIncreaseOnRankUp();
            Speed += GetSpeedIncreaseOnRankUp();
            // Incrementa el efecto de bonificaci�n de resistencia al subir de rango
            ResistanceBonus += 0.05f; // Incremento adicional del 5% en la bonificaci�n de resistencia de los pantalones

        }
        else
        {
            // El rango ya est� en su m�ximo
            // Manejar el error o mostrar un mensaje al jugador
        }
    }

    private int GetPowerIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de poder al subir de nivel
        return Level * Rank * 2;
    }

    private int GetDefenseIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de defensa al subir de nivel
        return Level * Rank * 2;
    }

    private int GetAttackIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de ataque al subir de nivel
        return Level * Rank * 2;
    }

    private int GetHealthIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de vida al subir de nivel
        return Level * Rank * 2;
    }

    private int GetSpeedIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de velocidad al subir de nivel
        return Level * Rank * 2;
    }

    private int GetPowerIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de poder al subir de rango
        return Rank * 10;
    }

    private int GetDefenseIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de defensa al subir de rango
        return Rank * 5;
    }

    private int GetAttackIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de ataque al subir de rango
        return Rank * 5;
    }

    private int GetHealthIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de vida al subir de rango
        return Rank * 5;
    }

    private int GetSpeedIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de velocidad al subir de rango
        return Rank * 5;
    }

    private int GetMaxRank()
    {
        // L�gica para determinar el rango m�ximo
        switch (Name)
        {
            case "Pants":
                return 7; // U
            default:
                return 0;
        }
    }
}

public class Gloves : Equipament
{
    public float AttackPercentIncrease { get; protected set; }
    public float CriticalHitBonus { get; protected set; }

    public Gloves(int id, string name, int maxLevel, int rank) : base(id, name, maxLevel, rank)
    {
        // Configura los valores iniciales espec�ficos de los guantes
        Power = 10;
        Defense = 5;
        Attack = 0;
        Health = 0;
        Speed = 0;
        AttackPercentIncrease = 0.1f; // Aumento de fuerza de ataque del 10%
        CriticalHitBonus = 0.1f; // Bonificaci�n de golpe cr�tico del 10%
    }

    public override void UpgradeLevel()
    {
        if (Level < MaxLevel)
        {
            Level++;
            Power += GetPowerIncreaseOnLevelUp();
            Defense += GetDefenseIncreaseOnLevelUp();
            Attack += GetAttackIncreaseOnLevelUp();
            Health += GetHealthIncreaseOnLevelUp();
            Speed += GetSpeedIncreaseOnLevelUp();
            // Incrementa el efecto de aumento de fuerza de ataque porcentual al subir de nivel
            AttackPercentIncrease += 0.05f; // Incremento adicional del 5% en la fuerza de ataque de los guantes

        }
        else
        {
            // El nivel ya est� en su m�ximo
            // Manejar el error o mostrar un mensaje al jugador
        }
    }

    public override void UpgradeRank()
    {
        if (Rank < GetMaxRank())
        {
            Rank++;
            Power += GetPowerIncreaseOnRankUp();
            Defense += GetDefenseIncreaseOnRankUp();
            Attack += GetAttackIncreaseOnRankUp();
            Health += GetHealthIncreaseOnRankUp();
            Speed += GetSpeedIncreaseOnRankUp();
            // Incrementa el efecto de bonificaci�n de golpe cr�tico al subir de rango
            CriticalHitBonus += 0.02f; // Incremento adicional del 5% en la bonificaci�n de golpe cr�tico de los guantes

        }
        else
        {
            // El rango ya est� en su m�ximo
            // Manejar el error o mostrar un mensaje al jugador
        }
    }

    private int GetPowerIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de poder al subir de nivel
        return Level * Rank * 2;
    }

    private int GetDefenseIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de defensa al subir de nivel
        return Level * Rank * 2;
    }

    private int GetAttackIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de ataque al subir de nivel
        return Level * Rank * 2;
    }

    private int GetHealthIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de vida al subir de nivel
        return Level * Rank * 2;
    }

    private int GetSpeedIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de velocidad al subir de nivel
        return Level * Rank * 2;
    }

    private int GetPowerIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de poder al subir de rango
        return Rank * 10;
    }

    private int GetDefenseIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de defensa al subir de rango
        return Rank * 5;
    }

    private int GetAttackIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de ataque al subir de rango
        return Rank * 5;
    }

    private int GetHealthIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de vida al subir de rango
        return Rank * 5;
    }

    private int GetSpeedIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de velocidad al subir de rango
        return Rank * 5;
    }

    private int GetMaxRank()
    {
        // L�gica para determinar el rango m�ximo
        switch (Name)
        {
            case "Gloves":
                return 7; // U
            default:
                return 0;
        }
    }
}

public class Shirt : Equipament
{
    public float HealthPercentIncrease { get; protected set; }
    public float HealthRegenerationPercent { get; protected set; }

    public Shirt(int id, string name, int maxLevel, int rank) : base(id, name, maxLevel, rank)
    {
        // Configura los valores iniciales espec�ficos de la camisa
        Power = 10;
        Defense = 5;
        Attack = 0;
        Health = 0;
        Speed = 0;
        HealthPercentIncrease = 0.1f; // Aumento de salud del 10%
        HealthRegenerationPercent = 0.05f; // Regeneraci�n de salud del 5% al final del turno
    }


    public override void UpgradeLevel()
    {
        if (Level < MaxLevel)
        {
            Level++;
            Power += GetPowerIncreaseOnLevelUp();
            Defense += GetDefenseIncreaseOnLevelUp();
            Attack += GetAttackIncreaseOnLevelUp();
            Health += GetHealthIncreaseOnLevelUp();
            Speed += GetSpeedIncreaseOnLevelUp();
            // Incrementa el efecto de aumento de salud porcentual al subir de nivel
            HealthPercentIncrease += 0.05f; // Incremento adicional del 5% en la cantidad m�xima de salud de la camisa

        }
        else
        {
            // El nivel ya est� en su m�ximo
            // Manejar el error o mostrar un mensaje al jugador
        }
    }

    public override void UpgradeRank()
    {
        if (Rank < GetMaxRank())
        {
            Rank++;
            Power += GetPowerIncreaseOnRankUp();
            Defense += GetDefenseIncreaseOnRankUp();
            Attack += GetAttackIncreaseOnRankUp();
            Health += GetHealthIncreaseOnRankUp();
            Speed += GetSpeedIncreaseOnRankUp();
            // Incrementa el efecto de regeneraci�n de salud al subir de rango
            HealthRegenerationPercent += 0.02f; // Incremento adicional del 2% en la regeneraci�n pasiva de salud al final del turno

        }
        else
        {
            // El rango ya est� en su m�ximo
            // Manejar el error o mostrar un mensaje al jugador
        }
    }

    private int GetPowerIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de poder al subir de nivel
        return Level * Rank * 2;
    }

    private int GetDefenseIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de defensa al subir de nivel
        return Level * Rank * 2;
    }

    private int GetAttackIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de ataque al subir de nivel
        return Level * Rank * 2;
    }

    private int GetHealthIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de vida al subir de nivel
        return Level * Rank * 2;
    }

    private int GetSpeedIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de velocidad al subir de nivel
        return Level * Rank * 2;
    }

    private int GetPowerIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de poder al subir de rango
        return Rank * 10;
    }

    private int GetDefenseIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de defensa al subir de rango
        return Rank * 5;
    }

    private int GetAttackIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de ataque al subir de rango
        return Rank * 5;
    }

    private int GetHealthIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de vida al subir de rango
        return Rank * 5;
    }

    private int GetSpeedIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de velocidad al subir de rango
        return Rank * 5;
    }

    private int GetMaxRank()
    {
        // L�gica para determinar el rango m�ximo
        switch (Name)
        {
            case "Shirt":
                return 7; // U
            default:
                return 0;
        }
    }
}

public class Helmet : Equipament
{
    public float MagicalResistancePercentIncrease { get; protected set; }
    public float PrecisionPercentBonus { get; protected set; }

    public Helmet(int id, string name, int maxLevel, int rank) : base(id, name, maxLevel, rank)
    {
        // Configura los valores iniciales espec�ficos del casco
        Power = 10;
        Defense = 5;
        Attack = 0;
        Health = 0;
        Speed = 0;
        MagicalResistancePercentIncrease = 0.1f; // Aumento de resistencia m�gica del 10%
        PrecisionPercentBonus = 0.05f; // Bonificaci�n de precisi�n del 5%
    }

    public override void UpgradeLevel()
    {
        if (Level < MaxLevel)
        {
            Level++;
            Power += GetPowerIncreaseOnLevelUp();
            Defense += GetDefenseIncreaseOnLevelUp();
            Attack += GetAttackIncreaseOnLevelUp();
            Health += GetHealthIncreaseOnLevelUp();
            Speed += GetSpeedIncreaseOnLevelUp();
            // Incrementa el efecto de resistencia m�gica al subir de nivel
            MagicalResistancePercentIncrease += 0.05f; // Incremento adicional del 5% en la resistencia m�gica del casco

        }
        else
        {
            // El nivel ya est� en su m�ximo
            // Manejar el error o mostrar un mensaje al jugador
        }
    }

    public override void UpgradeRank()
    {
        if (Rank < GetMaxRank())
        {
            Rank++;
            Power += GetPowerIncreaseOnRankUp();
            Defense += GetDefenseIncreaseOnRankUp();
            Attack += GetAttackIncreaseOnRankUp();
            Health += GetHealthIncreaseOnRankUp();
            Speed += GetSpeedIncreaseOnRankUp();
            // Incrementa el efecto de bonificaci�n de precisi�n al subir de rango
            PrecisionPercentBonus += 0.02f; // Incremento adicional del 2% en la precisi�n del casco

        }
        else
        {
            // El rango ya est� en su m�ximo
            // Manejar el error o mostrar un mensaje al jugador
        }
    }

    private int GetPowerIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de poder al subir de nivel
        return Level * Rank * 2;
    }

    private int GetDefenseIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de defensa al subir de nivel
        return Level * Rank * 2;
    }

    private int GetAttackIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de ataque al subir de nivel
        return Level * Rank * 2;
    }

    private int GetHealthIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de vida al subir de nivel
        return Level * Rank * 2;
    }

    private int GetSpeedIncreaseOnLevelUp()
    {
        // L�gica para determinar el incremento de velocidad al subir de nivel
        return Level * Rank * 2;
    }

    private int GetPowerIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de poder al subir de rango
        return Rank * 10;
    }

    private int GetDefenseIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de defensa al subir de rango
        return Rank * 5;
    }

    private int GetAttackIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de ataque al subir de rango
        return Rank * 5;
    }

    private int GetHealthIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de vida al subir de rango
        return Rank * 5;
    }

    private int GetSpeedIncreaseOnRankUp()
    {
        // L�gica para determinar el incremento de velocidad al subir de rango
        return Rank * 5;
    }

    private int GetMaxRank()
    {
        // L�gica para determinar el rango m�ximo
        switch (Name)
        {
            case "Helmet":
                return 7; // U
            default:
                return 0;
        }
    }
}