public class Board
{
    public Dictionary<string, List<Cart>> Columns { get; set; }

    public Board()
    {
        Columns = new Dictionary<string, List<Cart>>
        {
            { "TODO", new List<Cart>()
              
            },
            { "IN PROGRESS", new List<Cart>
                {
                    new Cart { Title = "Örnek Kart 2", Description = "İçerik 2", TeamMember = new Team(3, "Derya"), Size = Size.XS }
                }
            },
            { "DONE", new List<Cart>
                {
                    new Cart { Title = "Örnek Kart 3", Description = "İçerik 3", TeamMember = new Team(4, "Alperen"), Size = Size.XL }
                }
            }
        };
    }
}
