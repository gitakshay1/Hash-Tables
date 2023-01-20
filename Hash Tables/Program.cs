namespace Hash_Tables
{
    public class Program
    {
        public static string key;
        public static void Main(string[] args)
        {
            MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
            
            string Paragraph = "“Paranoids are not paranoid because they are " +
              "paranoid but because they keep putting themselves deliberately into"  +
              " paranoid avoidable situations";
            string[] letters = Paragraph.ToLower().Split(" ");

            foreach (string value in letters)
            {
                
               hash.Add(key, value);
            }
            hash.frequencyOfWords("paranoid");
            Console.ReadLine();
            hash.Remove("avoidable");


        }
    }
}
