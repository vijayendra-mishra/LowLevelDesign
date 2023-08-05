public class Card
{

    public string Value { get; set; }
    public string Suit { get; set; }
    public int Points { get; set; }

    public Card()
    {
        Value = "Joker";
        Suit = String.Empty;
        Points = 0;
    }

    public Card(int points, string suit)
    {
        Points = points;
        Suit = suit;
        Value = points switch
        {
            1 => "A",
            11 => "J",
            12 => "Q",
            13 => "K",
             _=> points.ToString(),
        };
    }

    public override string ToString()
    {
        if (string.IsNullOrEmpty(Suit)) return $"{Value}";
        return $"{Value}-{Suit}";
    }


}

