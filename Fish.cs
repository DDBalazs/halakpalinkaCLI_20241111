using System.Windows.Markup;

namespace halak_palinkaCLI_20241111;

internal class Fish
{
    private int top;
    private int depth;
    private string spacies;
    private float weight ;
    private bool weightIsSet = false;

    public float Weight
    {
        get => weight;
        set
        {
            if(value < .5 || value > 40)
            {
                throw new Exception($"\nbeállítani kívánt érték: {value}" +
                    $"\na weight értéke [0.5; 40.0] közötti intervallumon belül valid");
            }
            if(weightIsSet && (value < weight * 0.9 || value > weight*1.1))
            {
                throw new Exception($"\na beállítani kívánt érték: {value}" +
                    $"\na jelenlegi értéke: {weight}" +
                    $"\naz új érték legfeljebb 10%-ban (+/- {weight*0.1}) térhet el az alap értéktől");
            }
            weight = value;
            weightIsSet = true;
        }
    }
    public bool Predator { get; }
    public int Top
    {
        get => top; 
        set
        {
            if (value < 0 || value > 400)
            {
                throw new Exception($"a beállítani kívánt érték: {value}" +
                    $"\na beállítani kivánt érték {value}" +
                    $"\na top érték [0;400] intervallumon belül valid");
            }
            top = value;
        }
    }
    public int Depth
    {
        get => depth; 
        set
        {
            if (value < 10 || value > 400)
            {
                throw new Exception($"a beállítani kívánt érték: {value}" +
                    $"\na beállítani kivánt érték {value}" +
                    $"\na top érték [0;400] intervallumon belül valid");
            }
            depth = value;
        }
    }
    public string Spacies
    {
        get => spacies; 
        set
        {
            if(value is null)
            {
                throw new Exception($"a spacies értke nem lehet: null");
            }
            if(value.Length < 3 || value.Length > 30)
            {
                throw new Exception($"a beállítani kívánt érték {value} (hossza: {value.Length}" +
                    $"\na spacies karakterlánc hossza [3;30] intervallum belül");
            }
            spacies = value;
        }
    }

    public override string ToString() => $"{Spacies} " +
            $"({(Predator ? "carnivore" : "herbivore")}" +
            $"[{Top} - {Top + Depth} cm ]" +
            $"{Weight: 00.0} kg";

    /// <summary>
    /// Egy Halat reprezentáló osztály
    /// </summary>
    /// <param name="weight">a hal súlya kg-ban 0,5 és 40 között valid, egyszerre max 10%-al változhat</param>
    /// <param name="predator"></param>
    /// <param name="top"></param>
    /// <param name="depth"></param>
    /// <param name="spacies"></param>
    public Fish(float weight, bool predator, int top, int depth, string spacies)
    {
        Weight = weight;
        Predator = predator;
        Top = top;
        Depth = depth;
        Spacies = spacies;
    }
}
