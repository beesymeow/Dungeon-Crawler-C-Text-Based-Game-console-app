using System.Reflection.PortableExecutable;

namespace Item;

public class ItemClass
{
    private string name;
    private int itemId;


    public string Name
    {
        get { return this.name; }
        set
        {
            if (value != "")
            {
                this.name = value;
            }
        }
    }

    public int ItemId
    {
        get { return this.itemId; }
        set
        {
            this.itemId = value;
        }
    }

    public ItemClass(string name, int itemId)
    {
        this.name = Name;
        this.itemId = itemId;
    }

    public virtual ItemClass Clone()    // Creates new instance of item from the allGameItems List
    {
        return new ItemClass(this.name, this.itemId);
    }

    
}