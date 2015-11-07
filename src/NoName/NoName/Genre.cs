namespace Domain
{
    public class Genre
    {
        //TODO hmmmm чувствуется какая то недосказанность

        public Genre(string name)
        {
            Name = name;
            Description = "";  
        }

       
        public string Name { get; protected set; }
        public string Description { get; protected set; }
    }
}