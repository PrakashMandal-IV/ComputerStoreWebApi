namespace ComputerStoreBackEnd.Data.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedBy { get; set; }
        public int? CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public int DeletedBy { get; set; }
    }
}
