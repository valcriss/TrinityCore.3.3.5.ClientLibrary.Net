namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class DbcFileAttribute : Attribute
    {
        public string Filename { get; set; }

        public DbcFileAttribute(string filename)
        {
            Filename = filename;
        }
    }
}