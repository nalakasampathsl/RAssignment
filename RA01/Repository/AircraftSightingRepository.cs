using RA01.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RA01.Repository
{
    public class AircraftSightingRepository : IAircraftSighting
    {
        private AircraftSightingDBEntities _context;
        public AircraftSightingRepository(AircraftSightingDBEntities ASContext)
        {
            this._context = ASContext;
        }


        public IEnumerable<AircraftSighting> GetAircraftSightings()
        {
            return _context.AircraftSightings.ToList();
        }

        public AircraftSighting GetAircraftSightingByID(int id)
        {
            return _context.AircraftSightings.Find(id);
        }

        public void InsertAircraftSighting(AircraftSighting aircraftSighting)
        {
            _context.AircraftSightings.Add(aircraftSighting);
        }

        public void DeleteAircraftSighting(int aircraftSightingID)
        {
            AircraftSighting aircraftSighting = _context.AircraftSightings.Find(aircraftSightingID);
            _context.AircraftSightings.Remove(aircraftSighting);
        }

        public void UpdateAircraftSighting(AircraftSighting aircraftSighting)
        {
            _context.Entry(aircraftSighting).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}