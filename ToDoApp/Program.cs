

var teamMember = new Team(1, "Ömer");
var memberList = new List<Team>()
{
    new Team(1,"Ömer Faruk"),
    new Team(2,"Burcu"),
   
};
var carts = new List<Cart>()
{
   new Cart("Deneme","Test Kartı_1",memberList[0],Size.M),
   new Cart("Deneme2","Test Kartı_2",memberList[1],Size.S),
};
var board = new Board();
board.Columns["TODO"] = carts;
var boardManager = new BoardManager(carts, memberList, board);


while (true)
{
    Console.Write("Lütfen yapmak istediğiniz işlemi seçiniz\n*******************************\n(1) Board Listelemek:\n(2) Board'a Kart Eklemek\n(3) Board'dan Kart Silmek\n(4) Kart Taşımak\n(5) Kart Güncellemek\n(6) Çıkış:  ");
    var choice = Convert.ToInt32(Console.ReadLine());



    switch (choice)
    {
        case 1:
            boardManager.ListBoard();
            break;
        case 2:
            boardManager.CartAdd();
            break;
        case 3:
            boardManager.CartRemove();
            break;
        case 4:
            boardManager.CartMove();
            break;
        case 5:
            boardManager.CartUpdate();
            break;
        default:
            break;
    }
    if (choice == 6) break;

}
