namespace prekick_api
{
    public class Match
    {
        public DateTime Date { get; set; }

        public Tuple<string, string>? Teams { get; set; }

        public Tuple<int, int>? Scores { get; set; }

        public Match()
        {
            Date = DateTime.Now;
            Teams = Tuple.Create("Test1", "Test2");
            Scores = Tuple.Create(1,2);
        }
    }
}
