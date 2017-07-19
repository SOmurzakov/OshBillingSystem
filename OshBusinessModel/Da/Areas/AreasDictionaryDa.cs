namespace OshBusinessModel.Da.Areas
{
    public class AreasDictionaryDa
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }

        public int ControllerId { get; set; }
        public string ControllerName { get; set; }
    }
}
