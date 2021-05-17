using RA01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA01.Repository
{
    interface IAircraftSighting : IDisposable
    {
        IEnumerable<AircraftSighting> GetAircraftSightings();

        AircraftSighting GetAircraftSightingByID(int aircraftSightingId);

        void InsertAircraftSighting(AircraftSighting aircraftSighting);

        void DeleteAircraftSighting(int aircraftSightingId);

        void UpdateAircraftSighting(AircraftSighting aircraftSightingId);

        void Save();
    }
}
