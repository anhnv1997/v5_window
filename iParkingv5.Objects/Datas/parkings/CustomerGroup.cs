namespace iParkingv5.Objects.Datas.parking
{
    public class CustomerGroup
    {
        public string Id { get; set; } = string.Empty;
        public string ParentId { get; set; }
        public string CustomerGroupCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public string Tax { get; set; }
        public bool IsCompany { get; set; }
    }
}
