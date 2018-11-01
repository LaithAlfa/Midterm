namespace MidtermLinq
{
    public class Author
    {
        public int AuthorID{ get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }

        public override string ToString()
        {
            return $"{AuthorFirstName} - {AuthorLastName}";
        }

    }
}