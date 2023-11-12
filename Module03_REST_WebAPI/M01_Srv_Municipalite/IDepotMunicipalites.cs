﻿using System.Collections.Generic;

namespace M01_Srv_Municipalite
{
    public interface IDepotMunicipalites
    {
        public Municipalite ChercherMunicipaliteParCodeGeographique(int p_codeGeographique);
        public IEnumerable<Municipalite> ListerMunicipalitesActives();
        public void DesactiverMunicipalite(Municipalite p_municipalite);
        public Municipalite AjouterMunicipalite(Municipalite p_municipalite);
        public void MAJMunicipalite(Municipalite p_municipalite);
    }
}
