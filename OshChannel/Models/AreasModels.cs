using OshBusinessModel.Da.Areas;

namespace OshChannel.Models
{
    public class CreateAreaAjaxModel
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string Remarks { get; set; }
        public int ControllerId { get; set; }
    }

    public class SaveAreasControllersAjaxModel
    {
        public SaveAreasControllersDa[] Areas { get; set; }
    }

    public class SaveAreasHousesAjaxModel
    {
        public AreasHousesDa[] Houses { get; set; }
    }
}