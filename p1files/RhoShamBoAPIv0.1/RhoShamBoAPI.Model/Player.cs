namespace RhoShamBoAPI.Model
{
    public class Player
    {
        // Fields
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Email { get; set; }


        // Constructors

        //When we are using a serializer - when we're sending a model/object to and from when we use HTTP, we want to serialize it. 
        //Most of the time our serializer needs a 0 parameter constructor
        public Player() { }
        public Player(int id, string name, string city, string email)
        {
            Id = id;
            Name = name;
            City = city;
            Email = email;
        }
        //Methods
         public Player(string name, string city, string email)
        {
            Name = name;
            City = city;
            Email = email;
        }
    }
}