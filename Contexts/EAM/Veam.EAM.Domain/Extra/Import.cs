namespace Veam.EAM.Domain
{
    public class Import
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public int FileSize { get; set; }
        public string ImportType { get; set; }
        public string HeaderRow { get; set; }
        public string FirstRow { get; set; }
        public string FieldMap { get; set; }
    }
}
