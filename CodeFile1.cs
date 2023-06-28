using System;
using System.Drawing;
using System.Windows.Forms;
    // The Main Window
class program : Form
{
    item item1;
    static void Main()
    {
        // Starts the window
        Application.Run(new program());
    }
    public program()
    {
        //on create
        //@debug
        item1 = new item("Test", "A black shirt. Great for Summer weather.", 89, Closeta.test.Shirt, "Shirt",true);
        item1.Move(25, 25);
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        //create the graphics and a pen with size of 3
        Graphics gfx = e.Graphics;
        Pen BlackS3 = new Pen(Color.Black, 3);
        // draw item1
        gfx.DrawRectangle(BlackS3, item1.border);
        gfx.DrawRectangle(BlackS3, item1.image_border);
        gfx.DrawImage(item1.image, item1.image_border);
        gfx.DrawString("Name: " + item1.name, new Font("Arial", 30), Brushes.Black, item1.NameP);
        gfx.DrawString("Type: " + item1.itemT, new Font("Arial", 30), Brushes.Black, item1.ItemP);
        gfx.DrawString("Clean: " + item1.clean.ToString(), new Font("Arial", 30), Brushes.Black, item1.CleanP);
        gfx.DrawString("Likeness: " + item1.likeness.ToString()+"%", new Font("Arial", 30), Brushes.Black, item1.LikeP);
        gfx.DrawString("Description: " + item1.description, new Font("Arial", 30), Brushes.Black, item1.DescriptionP);
    }
}
class item
{
    static int count;
    public int id;
    public string name;
    public string description;
    public int likeness;
    public Rectangle border;
    public Rectangle image_border;
    public Image image;
    public string itemT;
    public bool clean;
    public Point NameP;
    public Point DescriptionP;
    public Point LikeP;
    public Point ItemP;
    public Point CleanP;
    public item(String n, string d, int l, Image i,string ii, bool c)
    {
        //assign data to variables
        //assign id
        id = count;
        count++;
        Console.WriteLine(id);
        //assign strings
        name =n;
        description =d;
        likeness = l;
        image = i;
        itemT = ii;
        clean = c;
        //create border and points
        border = new Rectangle(0,0,500,800);
        image_border = new Rectangle(0,0,425,400);
        Point tempP = new Point(0, 0);
        NameP = tempP;
        DescriptionP = tempP;
        LikeP = tempP;
        ItemP = tempP;
        CleanP = tempP;
        MatchRecs();
    }
    public void Move(int x, int y)
    {
        //move the border
        border.X = x;
        border.Y = y;
        MatchRecs();
    }
    private void MatchRecs()
    {
        //move the image_border realtive to the border
        image_border.X = border.X + 30;
        image_border.Y = border.Y + 30;
        //move down the Name
        NameP = new Point(image_border.X, image_border.Bottom + 10);
        //move down item type
        ItemP = new Point(NameP.X,NameP.Y+40);
        //move down the Description
        DescriptionP = new Point(ItemP.X, ItemP.Y + 40);
        //move down the clean
        CleanP = new Point(DescriptionP.X,DescriptionP.Y+40);
        //move down the likness
        LikeP = new Point(CleanP.X, CleanP.Y + 40);
    }
}