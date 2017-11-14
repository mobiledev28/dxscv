using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCVData;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.Mvc;
using System.Collections;

namespace DXSCV.Helpers
{
    public class SchedulerDataHelper
    {
        public static System.Collections.IEnumerable GetResources()
        {
            TCADBHMTEntities db = new TCADBHMTEntities();
            List<SCV_DBResources> rssList = new List<SCV_DBResources>();
            rssList = db.SCV_DBResources.ToList();
            return rssList;
        }
        public static System.Collections.IEnumerable GetAppointments(int cuentaId)
        {
            TCADBHMTEntities db = new TCADBHMTEntities();
            List<SCV_DBAppointments> aptList = new List<SCV_DBAppointments>();
            aptList = db.SCV_DBAppointments.Where(a => a.CuentaId == cuentaId).ToList();
            return aptList;
        }
        public static SchedulerDataObject DataObject
        {
            get
            {
                return new SchedulerDataObject()
                {
                    Appointments = GetAppointments(0),
                    Resources = GetResources()
                };
            }
        }

        public class AppointmentDataAccessor
        {
            public static void InsertAppointment(SCV_DBAppointments appt)
            {
                if (appt == null)
                    return;
                TCADBHMTEntities db = new TCADBHMTEntities();
                appt.UniqueID = appt.GetHashCode();
                db.SCV_DBAppointments.Add(appt);
                db.SaveChanges();
            }
            public static void UpdateAppointment(SCV_DBAppointments appt)
            {
                if (appt == null)
                    return;
                TCADBHMTEntities db = new TCADBHMTEntities();
                SCV_DBAppointments query = (SCV_DBAppointments)(from carSchedule
                                                          in db.SCV_DBAppointments
                                                      where carSchedule.UniqueID == appt.UniqueID
                                                      select carSchedule).SingleOrDefault();

                query.UniqueID = appt.UniqueID;
                query.StartDate = appt.StartDate;
                query.EndDate = appt.EndDate;
                query.AllDay = appt.AllDay;
                query.Subject = appt.Subject;
                query.Description = appt.Description;
                query.Location = appt.Location;
                query.RecurrenceInfo = appt.RecurrenceInfo;
                query.ReminderInfo = appt.ReminderInfo;
                query.Status = appt.Status;
                query.Type = appt.Type;
                query.Label = appt.Label;
                query.ResourceID = appt.ResourceID;
                query.CuentaId = appt.CuentaId;
                db.SaveChanges();
            }
            public static void RemoveAppointment(SCV_DBAppointments appt)
            {
                TCADBHMTEntities db = new TCADBHMTEntities();
                SCV_DBAppointments query = (SCV_DBAppointments)(from carSchedule
                                                          in db.SCV_DBAppointments
                                                      where carSchedule.UniqueID == appt.UniqueID
                                                      select carSchedule).SingleOrDefault();
                db.SCV_DBAppointments.Remove(query);
                db.SaveChanges();
            }
        }
    }

    
}