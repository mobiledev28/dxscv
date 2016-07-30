using System.Web.Mvc;

namespace DXSCVWeb.Controllers
{
    public partial class EditingController : DemoController
    {
        public override string Name { get { return "Editing"; } }

        public ActionResult Index()
        {
            return RedirectToAction("EditModes");
        }

        public ActionResult EditModesAddNewPartial()
        {
            return RedirectToAction("EditModes");
        }
        public ActionResult EditModesUpdatePartial()
        {
            return RedirectToAction("EditModes");
        }
        public ActionResult EditModesDeletePartial()
        {
            return RedirectToAction("EditModes");
        }
    }
}
