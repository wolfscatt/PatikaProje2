public class Cart
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Team TeamMember { get; set; }
    public Size Size { get; set; }

    public Cart()
    {
        
    }

    public Cart(string title, string description, Team teamMember, Size size)
    {
        Title = title;
        Description = description;
        TeamMember = teamMember;
        Size = size;
    }
}
