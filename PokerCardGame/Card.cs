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

    public Card(int _points, string _suit)
    {
        Points = _points;
        Suit = _suit;
        switch (_points)
        {
            case 1:
                Value = "A";
                break;
            case 11:
                Value = "J";
                break;
            case 12:
                Value = "Q";
                break;
            case 13:
                Value = "K";
                break;
            default:
                Value = _points.ToString();
                break;
        }

    }

    public override string ToString()
    {
        if (string.IsNullOrEmpty(Suit)) return $"{Value}";
        return $"{Value}-{Suit}";
    }


}

