



public class BoardManager : IBoardService
{
    private readonly string star = new string('*', 15);
    private List<Cart> carts;
    private List<Team> teams;
    private Board board;

    public BoardManager(List<Cart> carts, List<Team> teams, Board board)
    {
        this.carts = carts;
        this.teams = teams;
        this.board = board;
    }
    public void CartAdd()
    {
        Console.Write($"Başlık Giriniz : ");
        var title = Console.ReadLine();
        Console.Write("İçerik Giriniz : ");
        var description = Console.ReadLine();
        Console.Write("Büyüklük Seçiniz -> XS(1), S(2), M(3), L(4), XL(5)");
        var size = Convert.ToInt32(Console.ReadLine());
        Console.Write("Kişi Seçiniz (ID) : ");
        var teamMember = Convert.ToInt32(Console.ReadLine());


        var sizes = (Size[])Enum.GetValues(typeof(Size));
        if (size > 0 && size-1 < sizes.Length)
        {
            var selectedSize = sizes[size-1];
            
            if (carts.Where(cart => cart.TeamMember.Id.Equals(teamMember)).Any())
            {
                var team = teams.Where(teamMemb => teamMemb.Id == teamMember).FirstOrDefault();
                var cart = new Cart(title, description, team, selectedSize);
                carts.Add(cart);
            }
            else
            {
                Console.WriteLine("Hatalı Giriş!");
            }
        }
        else
        {
            Console.WriteLine("Geçersiz Büyüklük seçimi!");
        }

    }

    public void CartMove()
    {
        Console.Write("Taşımak istediğiniz kartın başlığını yazınız: ");
        var cardTitle = Console.ReadLine().ToLower();

        foreach (var col in board.Columns.Keys)
        {
            foreach (var card in board.Columns[col])
            {
                if (cardTitle == card.Title.ToLower())
                {
                    Console.WriteLine($"Bulunan Card Bilgileri\n{star}\nBaşlık: {card.Title}\nİçerik: {card.Description}\nAtanan Kişi: {card.TeamMember.Name}\nBüyüklük: {card.Size}");
                    Console.Write("Lütfen Taşımak istediğiniz Line'ı Seçiniz:\n(1) TODO\n(2) IN PROGRESS\n(3) DONE: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            board.Columns[col].Remove(card);
                            board.Columns["TODO"].Add(card);
                            break;
                        case "2":
                            board.Columns[col].Remove(card);
                            board.Columns["IN PROGRESS"].Add(card);
                            break;
                        case "3":
                            board.Columns[col].Remove(card);
                            board.Columns["DONE"].Add(card);
                            break;
                        default:
                            Console.WriteLine("Hatalı Giriş!");
                            break;
                    }
                    ListBoard();
                    return;
                }
                else
                {
                    Console.Write("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* İşlemi sonlandırmak için : (1)\nYeniden denemek için : (2): ");
                    var choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        break;
                    }
                    else if (choice == "2")
                    {
                        CartMove();
                    }
                }
            }

        }

        
    }

    public void CartRemove()
    {
        Console.Write("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.Lütfen kart başlığını yazınız:  ");
        var cardTitle = Console.ReadLine().ToLower();
        foreach (var col in board.Columns.Keys)
        {
            foreach (var card in board.Columns[col])
            {
                if (cardTitle == card.Title.ToLower())
                {
                    board.Columns[col].Remove(card);
                    carts.Remove(card);
                    Console.WriteLine($"Aşağıda bulunan kart silinmiştir.\nBaşlık      :{card.Title}\nİçerik      :{card.Description}\nAtanan Kişi :{card.TeamMember.Name}\nBüyüklük    :{card.Size}\n");

                    return;
                }
                else
                {
                    Console.Write("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* İşlemi sonlandırmak için : (1)\nYeniden denemek için : (2): ");
                    var choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        break;
                    }
                    else if (choice == "2")
                    {
                        CartRemove();
                    }
                }
            }
        }
    }

    public void CartUpdate()
    {
        Console.Write("Öncelikle Güncellemek istediğiniz kartı seçmeniz gerekiyor.Lütfen kart başlığını yazınız:  ");
        var cardTitle = Console.ReadLine().ToLower();
        foreach (var col in board.Columns.Keys)
        {
            foreach (var card in board.Columns[col])
            {
                if (cardTitle == card.Title.ToLower())
                {
                    Console.WriteLine($"Güncellemek istediğiniz kart. ->\nBaşlık      :{card.Title}\nİçerik      :{card.Description}\nAtanan Kişi :{card.TeamMember.Name}\nBüyüklük    :{card.Size}\n");
                    Console.WriteLine(star);
                    Console.WriteLine($"Güncellemek istediğiniz verileri giriniz ->");
                    Console.Write($"Başlık Giriniz : ");
                    var title = Console.ReadLine();
                    Console.Write("İçerik Giriniz : ");
                    var description = Console.ReadLine();
                    Console.Write("Büyüklük Seçiniz -> XS(1), S(2), M(3), L(4), XL(5)");
                    var size = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Kişi Seçiniz (ID) : ");
                    var teamMember = Convert.ToInt32(Console.ReadLine());

                    card.Title = title;
                    card.Description = description;
                    card.Size = size == 1 ? Size.XS : size == 2 ? Size.S : size == 3 ? Size.M : size == 4 ? Size.L : size == 5 ? Size.XL : Size.M ;
                    card.TeamMember = teamMember == 1 ? teams[0] : teamMember == 2 ? teams[1] : teamMember == 3 ? teams[2] : teamMember == 4 ? teams[3] : new Team();

                    Console.WriteLine($"Güncellenen Kart. ->\nBaşlık      :{card.Title}\nİçerik      :{card.Description}\nAtanan Kişi :{card.TeamMember.Name}\nBüyüklük    :{card.Size}\n");

                    return;
                }
                else
                {
                    Console.Write("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* İşlemi sonlandırmak için : (1)\nYeniden denemek için : (2): ");
                    var choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        break;
                    }
                    else if (choice == "2")
                    {
                        CartUpdate();
                    }
                }
            }
        }
    }

    public void ListBoard()
    {
        foreach (var col in board.Columns.Keys)
        {
            Console.WriteLine($"{col} Line\n{star}");

            foreach (var card in board.Columns[col])
            {
                Console.WriteLine($"Başlık      :{card.Title}\nİçerik      :{card.Description}\nAtanan Kişi :{card.TeamMember.Name}\nBüyüklük    :{card.Size}\n-\n");
            }
        }
    }

    private void DefaultBoard(Cart cart)
    {
        Console.WriteLine($"{ColumnName.TODO} Line\n{star}\nBaşlık      :\nİçerik      :\nAtanan Kişi :\nBüyüklük    :\n-\n" +
            $"Başlık      :\nİçerik      :\nAtanan Kişi :\nBüyüklük    :\n\n\n" +
            $"{ColumnName.INPROGRESS} Line\n{star}\nBaşlık      :\nİçerik      :\nAtanan Kişi :\nBüyüklük    :\n\n\n" +
            $"{ColumnName.DONE} Line\n{star}\nBaşlık      :\nİçerik      :\nAtanan Kişi :\nBüyüklük    :");

    }
}