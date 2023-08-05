public class Player
{
    public int Id { get; set; }
    public List<Card> CardsDealt = new();

    public Player(int id)
    {
        Id = id;
    }

    public override string ToString()
    {
        return $"Cards in hand of Player {Id} : {string.Join<Card>(',', CardsDealt.ToArray())}";
    }

}