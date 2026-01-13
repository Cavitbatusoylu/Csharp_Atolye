Araba araba = new Araba();
//araba.marka = "Toyota";
//araba.model = "Corolla";

//Console.WriteLine("Marka: " + araba.marka);
//Console.WriteLine("Model: " + araba.model);

//araba.setMarka("Toyota");
//araba.setModel("Corolla");

//Console.WriteLine("Marka: " + araba.getMarka());
//Console.WriteLine("Model: " + araba.getModel());

//class Araba
//{
//    private string marka;
//    private string model;

//    public void setMarka(string marka)
//    {
//        this.marka = marka;
//    }
//    public string getMarka()
//    {
//        return marka;
//    }
//    public void setModel(string model)
//    {
//        this.model = model;
//    }
//    public string getModel()
//    {
//        return model;
//    }
//}

class Araba
{
    private string marka;
    public string Marka
    {
        get
        {
            return marka;
        }
        set
        {
            marka = value;
        }
    }

    private string Model { get; set; }
    public string Beygir { get; set;  }


}