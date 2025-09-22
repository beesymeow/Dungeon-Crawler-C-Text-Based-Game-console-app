namespace Role; //archer mage and soldier  class

public class RoleClass
{
    private string name;
   
    public string Name
    {
        get { return this.name; }
        set
        {
            if (this.name != "")
            {
                this.name = value;
            }
        }
    }



    public RoleClass(string name, List<int> stats)
    {
        Name = name;
    }
}